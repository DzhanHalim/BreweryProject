using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity>
    {
        List<TEntity> GetAll(Func<TEntity, bool> filter = null);

        TEntity GetById(Func<TEntity, bool> filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
