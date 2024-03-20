using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
