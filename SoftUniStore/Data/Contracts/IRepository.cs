using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SoftUniStore.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Delete(TEntity entity);

        TEntity GetById(int id);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where);

        TEntity Single(Expression<Func<TEntity, bool>> where);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> GetAll();
    }
}
