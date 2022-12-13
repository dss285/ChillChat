using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Linq.Expressions;

namespace Aeon.Core
{
    public interface IBaseDbRepository
    {
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        TransactionWrapper BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void CopyValues<TEntity>(TEntity from, TEntity to) where TEntity : class;
        void CreateNewContext();
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        IQueryable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> pred) where TEntity : class;
        IQueryable<TEntity> FindExisting<TEntity>(Expression<Func<TEntity, bool>> pred) where TEntity : class, IObjectInfo;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        IQueryable<TEntity> GetAllExisting<TEntity>() where TEntity : class, IObjectInfo;
        BaseDbContext GetContext();
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        Task InsertAsync<TEntity>(TEntity entity) where TEntity : class;
        void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task InsertRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void SaveChanges();
        Task SaveChangesAsync();
        void SoftDelete(IObjectInfo entity);
    }
}