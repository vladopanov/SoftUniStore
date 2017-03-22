using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SoftUniStore.Data.Contracts;

namespace SoftUniStore.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> Set;

        public Repository(DbSet<TEntity> context)
        {
            this.Set = context;
        }

        public void Add(TEntity entity)
        {
            this.Set.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.Set.Remove(entity);
        }

        public TEntity GetById(int id)
        {
            return this.Set.Find(id);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> @where)
        {
            return this.Set.Where(where);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> @where)
        {
            return this.Set.First(where);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> @where)
        {
            return this.Set.FirstOrDefault(where);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Set;
        }
    }
}
