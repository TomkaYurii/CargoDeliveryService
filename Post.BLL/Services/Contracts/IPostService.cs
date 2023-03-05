using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.BLL.Services.Contracts
{
    public interface IPostService
    {
        //Task<Tuple<List<Post>, PagerContext>> GetPosts(Topic topic, bool includeDeleted, int pageIndex);
        //Task<Tuple<List<Post>, PagerContext>> GetPosts(Topic topic, int lastLoadedPostID, bool includeDeleted);
        //Task<List<Post>> GetPosts(Topic topic, bool includeDeleted);
        //Task<Post> Get(int postID);
        //Task<Tuple<int, Topic>> GetTopicPageForPost(Post post, bool includeDeleted);
        //Task<int> GetPostCount(User user);
        //Task<PostEdit> GetPostForEdit(Post post, User user);
        //Task Delete(Post post, User user);
        //Task Undelete(Post post, User user);
        //Task<string> GetPostForQuote(Post post, User user, bool forcePlainText);
        //Task<List<IPHistoryEvent>> GetIPHistory(string ip, DateTime start, DateTime end);
        //Task<int> GetLastPostID(int topicID);
        //Task<VotePostContainer> GetVoters(Post post);
        //Task<int> GetVoteCount(Post post);
        //Task<List<int>> GetVotedPostIDs(User user, List<Post> posts);
        //string GenerateParsedTextPreview(string text, bool isPlainText);
        //Task<Tuple<int, bool>> ToggleVoteReturnCountAndIsVoted(Post post, User user, string userUrl, string topicUrl, string topicTitle);
    }

}
