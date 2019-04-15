using miniecommerce.ENTITIES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace miniecommerce.DAL.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
         
        void Delete(T entity);
        int Max(Expression<Func<T, int>> filter);
        int Sum(Expression<Func<T, bool>> filterWhere, Func<T, int> filterSum);
        decimal Sum(Expression<Func<T, bool>> filterWhere, Func<T, decimal> filterSum);
    }
}
