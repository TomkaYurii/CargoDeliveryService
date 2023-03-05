using Post.DAL.Entities;

namespace Post.DAL.Repositories.Contracts;

public interface IPostRepository
{
    Task<int> Create(int topicID, int parentPostID, string IP, bool isFirstInTopic, bool showSig, int userID, string name, string title, string fullText, DateTime postTime, bool isEdited, string lastEditName, DateTime? lastEditTime, bool isDeleted, int votes);
    Task<bool> Update(ForumPost post);
    //Task<List<Post>> Get(int topicID, bool includeDeleted, int startRow, int pageSize);
    //Task<List<Post>> Get(int topicID, bool includeDeleted);
    //Task<int> GetReplyCount(int topicID, bool includeDeleted);
    Task<ForumPost> Get(int postID);
    //Task<Dictionary<int, DateTime>> GetPostIDsWithTimes(int topicID, bool includeDeleted);
    Task<int> GetPostCount(int userID);
    //Task<List<IPHistoryEvent>> GetIPHistory(string ip, DateTime start, DateTime end);
    //Task<int> GetLastPostID(int topicID);
    //Task<int> GetVoteCount(int postID);
    //Task<int> CalculateVoteCount(int postID);
    //Task SetVoteCount(int postID, int votes);
    //Task VotePost(int postID, int userID);
    //Task<Dictionary<int, string>> GetVotes(int postID);
    //Task<List<int>> GetVotedPostIDs(int userID, List<int> postIDs);
    Task<ForumPost> GetLastInTopic(int topicID);
    Task<int> DeleteVote(int postID, int userID);
}