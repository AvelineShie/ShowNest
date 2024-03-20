using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        TEntity GetById<TId>(TId id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression);
        bool Any(Expression<Func<TEntity, bool>> expression);
        List<TEntity> List(Expression<Func<TEntity, bool>> expression);

    }
}
