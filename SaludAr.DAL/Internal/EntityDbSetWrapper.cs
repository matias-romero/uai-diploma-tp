using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SaludAr.DAL.Internal
{
    public interface IReadOnlyEntityDbSet<TEntity> where TEntity : class
    {
        TEntity Find(params object[] keyValues);
        TEntity[] FindAll();
        TEntity[] FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity[] FindAllWithoutRelatedEntities(Expression<Func<TEntity, bool>> predicate);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IEntityDbSet<TEntity> : IReadOnlyEntityDbSet<TEntity> where TEntity: class 
    {
        TEntity Add(TEntity entity);
        TEntity Remove(TEntity entity);
        TEntity Attach(TEntity entity);
        TEntity Create();
    }

    internal class EntityDbSetWrapper<TEntity> : IEntityDbSet<TEntity> where TEntity : class
    {
        private readonly IDbSet<TEntity> _internalDbSet;

        public EntityDbSetWrapper(IDbSet<TEntity> internalDbSet)
        {
            _internalDbSet = internalDbSet;
        }

        public TEntity Find(params object[] keyValues)
        {
            return _internalDbSet.Find(keyValues);
        }

        public TEntity Add(TEntity entity)
        {
            return _internalDbSet.Add(entity);
        }

        public TEntity Remove(TEntity entity)
        {
            return _internalDbSet.Remove(entity);
        }

        public TEntity Attach(TEntity entity)
        {
            return _internalDbSet.Attach(entity);
        }

        public TEntity Create()
        {
            return _internalDbSet.Create();
        }

        public TEntity[] FindAll()
        {
            return _internalDbSet.AsNoTracking().ToArray();
        }

        public TEntity[] FindAllWithoutRelatedEntities(Expression<Func<TEntity, bool>> predicate)
        {
            return _internalDbSet.AsNoTracking().Where(predicate).ToArray();
        }

        public TEntity[] FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.Where(predicate).ToArray();
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _internalDbSet.Any(predicate);
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _internalDbSet.AsNoTracking();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
