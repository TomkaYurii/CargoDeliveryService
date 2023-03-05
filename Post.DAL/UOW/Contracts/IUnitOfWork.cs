using Post.DAL.Repositories.Contracts;

namespace Post.DAL.UOW.Contracts
{
    public interface IUnitOfWork
    {
        IPostRepository _postRepository { get; }
        ITopicRepository _topicRepository { get; }
        void Commit();
        void Dispose();
    }
}
