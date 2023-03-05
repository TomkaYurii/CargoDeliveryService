using Dapper;
using Microsoft.Data.SqlClient;
using Post.DAL.Entities;
using Post.DAL.Repositories.Contracts;
using System.Data;

namespace Post.DAL.Repositories;

public class PostRepository : GenericRepository<ForumPost>, IPostRepository
{
    public PostRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "pf_Post")
    {

    }

    private const string PostFields = "PostID, TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes";



    public virtual async Task<int> create(int topicid, int parentpostid, string ip, bool isfirstintopic, bool showsig, int userid, string name, string title, string fulltext, DateTime posttime, bool isedited, string lasteditname, DateTime? lastedittime, bool isdeleted, int votes)
    {
        Task<int> postid = null;

        await _sqlobjectfactory.getconnection().usingasync(connection =>
            postid = connection.querysingleasync<int>("insert into pf_post (topicid, parentpostid, ip, isfirstintopic, showsig, userid, name, title, fulltext, posttime, isedited, lasteditname, lastedittime, isdeleted, votes) values (@topicid, @parentpostid, @ip, @isfirstintopic, @showsig, @userid, @name, @title, @fulltext, @posttime, @isedited, @lasteditname, @lastedittime, @isdeleted, @votes);select cast(scope_identity() as int)", new { topicid = topicid, parentpostid = parentpostid, ip = ip, isfirstintopic = isfirstintopic, showsig = showsig, userid = userid, name = name, title = title, fulltext = fulltext, posttime = posttime, isedited = isedited, lastedittime = lastedittime, lasteditname = lasteditname, isdeleted = isdeleted, votes = votes }));
        var key = string.format(cachekeys.postpages, topicid);
        _cache.removecacheobject(key);
        return await postid;
    }

    public async Task<bool> Update(ForumPost post)
    {
        var result = await _sqlConnection.ExecuteAsync("UPDATE pf_Post SET TopicID = @TopicID, ParentPostID = @ParentPostID, IP = @IP, IsFirstInTopic = @IsFirstInTopic, ShowSig = @ShowSig, UserID = @UserID, Name = @Name, Title = @Title, FullText = @FullText, PostTime = @PostTime, IsEdited = @IsEdited, LastEditName = @LastEditName, LastEditTime = @LastEditTime, IsDeleted = @IsDeleted, Votes = @Votes WHERE PostID = @PostID",
            param: new { });

        new { post.TopicID, post.ParentPostID, post.IP, post.IsFirstInTopic, post.ShowSig, post.UserID, post.Name, post.Title, post.FullText, post.PostTime, post.IsEdited, post.LastEditTime, post.LastEditName, post.IsDeleted, post.Votes, post.PostID }));
        var key = string.Format(CacheKeys.PostPages, post.TopicID);
        _cache.RemoveCacheObject(key);
        return result.Result == 1;
    }

    //	public async Task<List<Post>> Get(int topicID, bool includeDeleted, int startRow, int pageSize)
    //	{
    //		var key = string.Format(CacheKeys.PostPages, topicID);
    //		var page = startRow == 1 ? 1 : (startRow - 1) / pageSize + 1;
    //		if (!includeDeleted)
    //		{
    //			// we're only caching paged threads that do not include deleted posts, since only moderators
    //			// ever see threads that way, a small percentage of users
    //			var cachedList = _cache.GetPagedListCacheObject<Post>(key, page);
    //			if (cachedList != null)
    //				return cachedList;
    //		}
    //		const string sql = @"
    //DECLARE @Counter int
    //SET @Counter = (@StartRow + @PageSize - 1)

    //SET ROWCOUNT @Counter;

    //WITH Entries AS ( 
    //SELECT ROW_NUMBER() OVER (ORDER BY PostTime)
    //AS Row, PostID, TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes 
    //FROM pf_Post WHERE TopicID = @TopicID 
    //AND ((@IncludeDeleted = 1) OR (@IncludeDeleted = 0 AND IsDeleted = 0)))

    //SELECT PostID, TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes
    //FROM Entries 
    //WHERE Row between 
    //@StartRow and @StartRow + @PageSize - 1

    //SET ROWCOUNT 0";
    //		Task<IEnumerable<Post>> posts = null;
    //		await _sqlObjectFactory.GetConnection().UsingAsync(connection =>
    //			posts = connection.QueryAsync<Post>(sql, new { TopicID = topicID, IncludeDeleted = includeDeleted, StartRow = startRow, PageSize = pageSize }));
    //		var list = posts.Result.ToList();
    //		if (!includeDeleted)
    //		{
    //			_cache.SetPagedListCacheObject(key, page, list);
    //		}
    //		return list;
    //	}

    //	public async Task<List<Post>> Get(int topicID, bool includeDeleted)
    //	{
    //		const string sql = "SELECT PostID, TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes FROM pf_Post WHERE TopicID = @TopicID AND ((@IncludeDeleted = 1) OR (@IncludeDeleted = 0 AND IsDeleted = 0)) ORDER BY PostTime";
    //		Task<IEnumerable<Post>> posts = null;
    //		await _sqlObjectFactory.GetConnection().UsingAsync(connection =>
    //			posts = connection.QueryAsync<Post>(sql, new { TopicID = topicID, IncludeDeleted = includeDeleted }));
    //		return posts.Result.ToList();
    //	}

    public async Task<ForumPost> GetLastInTopic(int topicID)
    {
        var post = await _sqlConnection.QuerySingleOrDefaultAsync<ForumPost>("SELECT TOP 1 " + PostFields + " FROM pf_Post WHERE TopicID = @TopicID AND IsDeleted = 0 ORDER BY PostTime DESC",
            param: new { TopicID = topicID },
            transaction: _dbTransaction);

        if (post == null)
            throw new KeyNotFoundException($"Couldn't found any post in {_tableName} with topicID [{topicID}] could not be found.");
        return post;
    }

    //public async Task<int> GetReplyCount(int topicID, bool includeDeleted)
    //{
    //	var sql = "SELECT COUNT(*) FROM pf_Post WHERE TopicID = @TopicID";
    //	if (!includeDeleted)
    //		sql += " AND IsDeleted = 0 AND IsFirstInTopic = 0";
    //	Task<int> replyCount = null;
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection =>
    //		replyCount = connection.ExecuteScalarAsync<int>(sql, new { TopicID = topicID }));
    //	return await replyCount;
    //}

    public async Task<ForumPost> Get(int postID)
    {
        var post = await _sqlConnection.QuerySingleOrDefaultAsync<ForumPost>("SELECT " + PostFields + " FROM pf_Post WHERE PostID = @PostID",
            param: new { PostID = postID },
            transaction: _dbTransaction);
        
        if(post == null)
            throw new KeyNotFoundException($"Couldn't found any post in {_tableName} with postID [{postID}] could not be found.");

        return  post;
    }

    //public async Task<Dictionary<int, DateTime>> GetPostIDsWithTimes(int topicID, bool includeDeleted)
    //{
    //	Task<IEnumerable<dynamic>> results = null;
    //	var sql = "SELECT PostID, PostTime FROM pf_Post WHERE TopicID = @TopicID";
    //	if (!includeDeleted)
    //		sql += " AND IsDeleted = 0";
    //	sql += " ORDER BY PostTime";
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection =>
    //		results = connection.QueryAsync(sql, new { TopicID = topicID }));
    //	var dictionary = results.Result.ToDictionary(r => (int) r.PostID, r => (DateTime) r.PostTime);
    //	return dictionary;
    //}

    public async Task<int> GetPostCount(int userID)
    {
        var postCount = await _sqlConnection.QuerySingleOrDefaultAsync<int>("SELECT COUNT(PostID) FROM pf_Post JOIN pf_Topic ON pf_Post.TopicID = pf_Topic.TopicID WHERE pf_Post.UserID = @UserID AND pf_Post.IsDeleted = 0 AND pf_Topic.IsDeleted = 0",
            param: new { UserID = userID },
            transaction: _dbTransaction);
        
        return postCount;
    }

    //public async Task<List<IPHistoryEvent>> GetIPHistory(string ip, DateTime start, DateTime end)
    //{
    //	Task<IEnumerable<IPHistoryEvent>> events = null;
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection =>
    //		events = connection.QueryAsync<IPHistoryEvent>("SELECT PostID AS ID, PostTime AS EventTime, UserID, Name, Title AS Description FROM pf_Post WHERE IP = @IP AND PostTime >= @Start AND PostTime <= @End", new { IP = ip, Start = start, End = end }));
    //	var list = events.Result.ToList();
    //	foreach (var item in list)
    //		item.Type = "Post";
    //	return list;
    //}

    //public async Task<int> GetLastPostID(int topicID)
    //{
    //	const string sql = "SELECT PostID FROM pf_Post WHERE TopicID = @TopicID AND IsDeleted = 0 ORDER BY PostTime DESC";
    //	Task<int> id = null;
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection => 
    //		id = connection.QuerySingleOrDefaultAsync<int>(sql, new { TopicID = topicID }));
    //	return await id;
    //}

    //public async Task<int> GetVoteCount(int postID)
    //{
    //	const string sql = "SELECT Votes FROM pf_Post WHERE PostID = @PostID";
    //	Task<int> votes = null;
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection => 
    //		votes = connection.QuerySingleOrDefaultAsync<int>(sql, new { PostID = postID }));
    //	return await votes;
    //}

    //public async Task<int> CalculateVoteCount(int postID)
    //{
    //	const string sql = "SELECT COUNT(*) FROM pf_PostVote WHERE PostID = @PostID";
    //	Task<int> count = null;
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection => 
    //		count = connection.ExecuteScalarAsync<int>(sql, new { PostID = postID }));
    //	return await count;
    //}

    //public async Task SetVoteCount(int postID, int votes)
    //{
    //	const string sql = "UPDATE pf_Post SET Votes = @Votes WHERE PostID = @PostID";
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection => 
    //		connection.ExecuteAsync(sql, new { Votes = votes, PostID = postID }));
    //}

    //public async Task VotePost(int postID, int userID)
    //{
    //	const string sql = "INSERT INTO pf_PostVote (PostID, UserID) VALUES (@PostID, @UserID)";
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection => 
    //		connection.ExecuteAsync(sql, new { PostID = postID, UserID = userID }));
    //}

    //public async Task<Dictionary<int, string>> GetVotes(int postID)
    //{
    //	Task<IEnumerable<dynamic>> results = null;
    //	const string sql = "SELECT V.UserID, U.Name FROM pf_PostVote V LEFT JOIN pf_PopForumsUser U ON V.UserID = U.UserID WHERE V.PostID = @PostID";
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection =>
    //		results = connection.QueryAsync(sql, new { PostID = postID }));
    //	var dictionary = results.Result.ToDictionary(r => (int) r.UserID, r => (string) r.Name);
    //	return dictionary;
    //}

    //public async Task<List<int>> GetVotedPostIDs(int userID, List<int> postIDs)
    //{
    //	Task<IEnumerable<int>> result = null;
    //	if (postIDs.Count == 0)
    //		return new List<int>();
    //	var inList = postIDs.Aggregate(string.Empty, (current, postID) => current + ("," + postID));
    //	if (inList.StartsWith(","))
    //		inList = inList.Remove(0, 1);
    //	var sql = $"SELECT PostID FROM pf_PostVote WHERE PostID IN ({inList}) AND UserID = @UserID";
    //	await _sqlObjectFactory.GetConnection().UsingAsync(connection =>
    //		result = connection.QueryAsync<int>(sql, new { UserID = userID }));
    //	var list = result.Result.ToList();
    //	return list;
    //}

    public async Task<int> DeleteVote(int postID, int userID)
    {
        var post = await _sqlConnection.ExecuteAsync("DELETE FROM pf_PostVote WHERE PostID = @postID AND UserID = @userID",
            param: new { PostID = postID, UserID = userID },
            transaction: _dbTransaction);
        return post;
    }
}