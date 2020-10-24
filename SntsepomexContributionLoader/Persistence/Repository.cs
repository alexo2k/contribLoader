using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SntsepomexContributionLoader.Repositories;

namespace SntsepomexContributionLoader.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(DbContext context) {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public TEntity Get(int id) {
            //return Context.Set<TEntity>().Find(id);
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll() {
            //return Context.Set<TEntity>().ToList();
            return _entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            //return Context.Set<TEntity>().Where(predicate);
            return _entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            //return Context.Set<TEntity>().FirstOrDefault(predicate);
            return _entities.FirstOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

    }
}
