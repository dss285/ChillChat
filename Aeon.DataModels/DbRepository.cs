using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Aeon.DataModels
{
    interface IDbRepository
    {
        public BaseDbContext GetContext();
        public TransactionWrapper BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
    public abstract class DbRepository : IDbRepository
    {
        protected BaseDbContext _dbContext;
        public DbRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BaseDbContext GetContext()
        {
            return _dbContext;
        }

        public TransactionWrapper BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            return _dbContext.BeginTransaction(isolationLevel);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Insert(entity);
        }
        public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _dbContext.InsertAsync(entity);
        }
        public async Task InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            await _dbContext.InsertRangeAsync(entities);
        }
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _dbContext.GetAll<TEntity>();
        }

        public IQueryable<TEntity> GetAllExisting<TEntity>() where TEntity : class, IObjectInfo
        {
            return _dbContext.GetAll<TEntity>().Where(t => t.ObjectInfo.Deleted == false);
        }

        public IQueryable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> pred) where TEntity : class
        {
            return _dbContext.FindAll(pred);
        }
        public IQueryable<TEntity> FindExisting<TEntity>(Expression<Func<TEntity, bool>> pred) where TEntity : class, IObjectInfo
        {
            return _dbContext.FindAll(pred).Where(t => t.ObjectInfo.Deleted == false);
        }
        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Attach(entity);
        }
        public void CopyValues<TEntity>(TEntity from, TEntity to) where TEntity : class
        {
            _dbContext.Entry(to).CurrentValues.SetValues(from);
        }
        public void SoftDelete(IObjectInfo entity)
        {
            entity.ObjectInfo.Deleted = true;
        }
    }
    public class TransactionWrapper : IDisposable
    {
        private bool _ownsTransaction;
        private IDbContextTransaction _transaction;

        public TransactionWrapper(IDbContextTransaction transaction, bool ownsTransaction)
        {
            _transaction = transaction;
            _ownsTransaction = ownsTransaction;
        }

        public void Dispose()
        {
            if (_ownsTransaction)
                _transaction.Dispose();
        }
        public void Rollback()
        {
            if (_ownsTransaction)
                _transaction.Rollback();
        }
        public void Commit()
        {
            if (_ownsTransaction)
                _transaction.Commit();
        }
    }
}
