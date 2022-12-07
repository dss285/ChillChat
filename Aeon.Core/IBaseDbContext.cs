using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Expressions;

namespace Aeon.Core
{
    public interface IBaseDbContext
    {
        TransactionWrapper BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
        IQueryable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> pred) where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        IConfiguration GetConfiguration();
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        Task InsertAsync<TEntity>(TEntity entity) where TEntity : class;
        void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task InsertRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void SetConfiguration(IConfiguration configuration);
    }
}