using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly DatabaseContext DbContext;
        protected readonly DbSet<TEntity> DbSet;
        private DbContext dbContext;

        public EfRepository(DatabaseContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public EfRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
            DbContext.SaveChanges();
            return entities;
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
            DbContext.SaveChanges();
            return entities;
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            DbContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
            DbContext.SaveChanges();
        }
        public List<TEntity> All()
        {
            return DbSet.ToList();
        }

        public TEntity GetById<TId>(TId id)
        {
            var entity = DbSet.Find(id);
            if (entity == null)
            {
               
                throw new Exception("Entity not found");
            }
            return entity;

        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            var entity = DbSet.FirstOrDefault(expression);
            if (entity == null)
            {
                
                throw new Exception("Entity not found");
            }
            return entity;
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            var entity = DbSet.SingleOrDefault(expression);
            if (entity == null)
            {
                
                throw new Exception("Entity not found");
            }
            return entity;
        }

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Any(expression);
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }
    }
}
