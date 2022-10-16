﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Aeon.DataModels
{
    public interface IDbContext

    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        IQueryable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

    }
    [Owned]
    public class ObjectInfo
    {
        public ObjectInfo()
        {
            Deleted = false;
            Creator = "internal";
            Modifier = "internal";
            Modified = SystemClock.Instance.GetCurrentInstant().InUtc();
            Created = SystemClock.Instance.GetCurrentInstant().InUtc();
        }
        public bool Deleted { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
        public ZonedDateTime Modified { get; set; }
        public ZonedDateTime Created { get; set; }
    }
    public interface IObjectInfo
    {
        public ObjectInfo ObjectInfo { get; set; }
    }
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        protected abstract string ConnectionString { get; set; }
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
        public IQueryable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> pred) where TEntity : class
        {
            return GetAll<TEntity>().Where(pred);
        }
        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            base.Set<TEntity>().Add(entity);
        }
        public async Task InsertAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await base.Set<TEntity>().AddAsync(entity);
        }
        public void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity :class
        {
            base.Set<TEntity>().AddRange(entities);
        }
        public async Task InsertRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            await base.Set<TEntity>().AddRangeAsync(entities);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public TransactionWrapper BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            IDbContextTransaction? transaction = base.Database.CurrentTransaction;
            if (transaction == null)
            {
                return new TransactionWrapper(base.Database.BeginTransaction(isolationLevel), true);
            }
            else
            {
                return new TransactionWrapper(transaction, false);
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString, 
                o => o.UseNodaTime());
        }
    }


 
    public static class DbUtils
    {
        public static async Task Update<TEntity>(this IQueryable<TEntity> queryable, Action<TEntity> action) where TEntity : class
        {
            await queryable.ForEachAsync(action);
        }

    }
}