using Post.DAL.Repositories.Contracts;
using Post.DAL.UOW.Contracts;
using System.Data;

namespace Post.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IPostRepository _postRepository { get; }
        public ITopicRepository _topicRepository { get; }

        readonly IDbTransaction _dbTransaction;

        public UnitOfWork(
            IPostRepository postRepository,
            ITopicRepository topicRepository,
            IDbTransaction dbTransaction)
        {
            _postRepository = postRepository;
            _topicRepository = topicRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                // By adding this we can have muliple transactions as part of a single request
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}

