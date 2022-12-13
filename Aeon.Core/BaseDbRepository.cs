using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aeon.Core
{
    public abstract class BaseDbRepository : IBaseDbRepository
    {
        protected BaseDbContext _dbContext;
        public BaseDbRepository(BaseDbContext dbContext)
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
            var changeTracker = _dbContext.ChangeTracker.Entries<IObjectInfo>();
            foreach (var entry in changeTracker)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity.ObjectInfo == null)
                            entry.Entity.ObjectInfo = new ObjectInfo();
                        break;
                }
            }
            _dbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            var changeTracker = _dbContext.ChangeTracker.Entries<IObjectInfo>();
            foreach (var entry in changeTracker)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity.ObjectInfo == null)
                            entry.Entity.ObjectInfo = new ObjectInfo();
                        break;
                }
            }
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
        public void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _dbContext.InsertRange(entities);
        }
        public async Task InsertRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
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
        public EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            return _dbContext.Attach(entity);
        }
        public void CopyValues<TEntity>(TEntity from, TEntity to) where TEntity : class
        {
            _dbContext.Entry(to).CurrentValues.SetValues(from);
        }
        public void SoftDelete(IObjectInfo entity)
        {
            entity.ObjectInfo.Deleted = true;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public abstract void CreateNewContext();
    }
    public class TransactionWrapper : IDisposable, IDbContextTransaction, IDbTransaction
    {
        private readonly bool _ownsTransaction;
        private readonly IDbContextTransaction _transaction;


        public IDbContextTransaction UnderlyingTransaction { get { return _transaction; } }

        public IDbConnection? Connection { get; protected set; }

        public IsolationLevel IsolationLevel { get; protected set; }

        public Guid TransactionId => UnderlyingTransaction.TransactionId;

        public TransactionWrapper(IDbContextTransaction transaction, IDbConnection connection, IsolationLevel level, bool ownsTransaction)
        {
            _transaction = transaction;
            _ownsTransaction = ownsTransaction;
            IsolationLevel = level;
            Connection = connection;
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

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_ownsTransaction)
                return _transaction.CommitAsync(cancellationToken);

            return Task.CompletedTask;
        }

        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_ownsTransaction)
                return _transaction.RollbackAsync(cancellationToken);
            return Task.CompletedTask;
        }

        public ValueTask DisposeAsync()
        {
            if (_ownsTransaction)
                return _transaction.DisposeAsync();
            return ValueTask.CompletedTask;
        }
    }
}
