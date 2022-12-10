using Aeon.Core;
using ChillChat.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChillChat.Services
{
    public abstract class BaseService<TEntity, TViewModel>
        where TEntity : class, IObjectInfo
        where TViewModel : class
    {
        protected ChillChatDbRepository _repository;
        public BaseService(ChillChatDbRepository repository)
        {
            _repository = repository;
        }
        protected abstract TViewModel MapToModel(TEntity entity);
        protected abstract TEntity MapFromModel(TViewModel model);
        public IEnumerable<TViewModel> GetAll()
        {
            var query = _repository.GetAllExisting<TEntity>();

            return query.ToList().Select(t => MapToModel(t));
        }
        public IEnumerable<TViewModel> FindAll(Expression<Func<TEntity, bool>> pred)
        {
            var query = _repository.FindExisting<TEntity>(pred);

            return query.ToList().Select(t => MapToModel(t));
        }
        public TEntity? Find(Expression<Func<TEntity, bool>> pred)
        {
            return FindInternal(pred).FirstOrDefault();
        }
        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> pred)
        {
            return await FindInternal(pred).FirstOrDefaultAsync();
        }
        public IQueryable<TEntity> FindInternal(Expression<Func<TEntity, bool>> pred)
        {
            var query = _repository.FindExisting(pred);
            return query;
        }
        public TViewModel? GetByExpression(Expression<Func<TEntity, bool>> pred)
        {
            var query = FindInternal(pred).Select(t => MapToModel(t));
            return query.FirstOrDefault();
        }
        protected TEntity Save(TViewModel model, Expression<Func<TEntity, bool>> pred)
        {
            var dbModel = Find(pred);
            var mappedModel = MapFromModel(model);
            if(dbModel == null)
            {
                dbModel = mappedModel;
                _repository.Insert(dbModel);
            } else
            {
                _repository.CopyValues(mappedModel, dbModel);
            }

            return dbModel;
        }
        protected async Task<TEntity> SaveAsync(TViewModel model, Expression<Func<TEntity, bool>> pred)
        {
            var dbModel = await FindAsync(pred);
            var mappedModel = MapFromModel(model);
            if (dbModel == null)
            {
                dbModel = mappedModel;
                _repository.Insert(dbModel);
            }
            else
            {
                _repository.CopyValues(mappedModel, dbModel);
            }

            return dbModel;
        }
        public abstract TEntity Save(TViewModel model);
        public abstract Task<TEntity> SaveAsync(TViewModel model);
        public void Insert(TViewModel model)
        {
            var dbModel = MapFromModel(model);
            _repository.Insert(dbModel);
        }
        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }
        public void Delete(TEntity entity, bool soft=true)
        {
            if (soft)
                _repository.SoftDelete(entity);
            else
                _repository.Delete(entity);

            _repository.SaveChanges();
        }
    }
}
