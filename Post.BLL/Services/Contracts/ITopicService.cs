using Post.DAL.Entities;

namespace Post.BLL.Services.Contracts
{
    public interface ITopicService
    {
        //Task<Tuple<List<Topic>, PagerContext>> GetTopics(Forum forum, bool includeDeleted, int pageIndex);
        //Task<Topic> Get(string urlName);
        //Task<Topic> Get(int topicID);
        //Task CloseTopic(Topic topic, User user);
        //Task OpenTopic(Topic topic, User user);
        //Task PinTopic(Topic topic, User user);
        //Task UnpinTopic(Topic topic, User user);
        //Task DeleteTopic(Topic topic, User user);
        //Task UndeleteTopic(Topic topic, User user);
        //Task UpdateTitleAndForum(Topic topic, Forum forum, string newTitle, User user);
        //Task<Tuple<List<Topic>, PagerContext>> GetTopics(User viewingUser, User postUser, bool includeDeleted, int pageIndex);
        //Task RecalculateReplyCount(Topic topic);
        //Task<List<Topic>> GetTopics(User viewingUser, Forum forum, bool includeDeleted);
        
        Task UpdateLast(ForumTopic topic);       //оновлення останнього топіку
        
        //Task<int> TopicLastPostID(int topicID);
        //Task HardDeleteTopic(Topic topic, User user);
        //Task SetAnswer(User user, Topic topic, Post post, string userUrl, string topicUrl);
        //Task QueueTopicForIndexing(int topicID);
        //Task CloseAgedTopics();
    }
}
