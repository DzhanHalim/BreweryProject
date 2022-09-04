using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDispoasable pattern , GC comes and cleanes the heap memory
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {

            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public List<TEntity> GetAll(Func<TEntity, bool> filter = null)
        {
            using (TContext context = new TContext())
            {
                // if ther isnt a filter, return the whole list from db, if there is a filter then use it 
                return filter == null ?
                     context.Set<TEntity>().ToList() :
                     context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById(Func<TEntity, bool> filter)
        {
            using (TContext context = new TContext())
            {

                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var modifiedEntity = context.Entry(entity);
                modifiedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
