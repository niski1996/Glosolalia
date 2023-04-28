using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Common.Contracts;
using Core.Common.Utils;
using Microsoft.EntityFrameworkCore;

namespace Core.Common.Data
{
    public abstract class DataRepositoryBase<T, U> : IDataRepository<T>
        where T : class, IIdentifiableEntity, new()
        where U : DbContext, new()
    {

        private DbSet<T> _getDbSetFromContext(U entityContext)
            /*TODO
             * reflection may cause slower work. May need changes. Example of repo in flatFinder
             */
        {
            var dbSet = entityContext.GetType().GetProperties()
            .FirstOrDefault(p => p.PropertyType == typeof(DbSet<T>));
            if (dbSet == null)
            {
                throw new ArgumentException($"The type '{typeof(T).Name}' is not a valid entity in this context.");
            }
            return (DbSet<T>)dbSet.GetValue(entityContext);
        }
        protected virtual T AddEntity(U entityContext, T entity)
        {

            var dbSet = _getDbSetFromContext(entityContext);
            var tmp = dbSet.AsQueryable().ToQueryString();
            var s = tmp.ToString();


            return dbSet.Add(entity).Entity;
        }

        protected virtual T UpdateEntity(U entityContext, T entity)
        {
            var dbSet = _getDbSetFromContext(entityContext);
            return (from e in dbSet
                    where e.EntityId == entity.EntityId
                    select e).FirstOrDefault(); }

        protected virtual IEnumerable<T> GetEntities(U entityContext)
        {
            var dbSet = _getDbSetFromContext(entityContext);
            return from e in dbSet
                   select e;
        }

        protected virtual T GetEntity(U entityContext, int id)
        {
            var dbSet = _getDbSetFromContext(entityContext);
            var query = (from e in dbSet
                         where e.EntityId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public T Add(T entity)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity);

                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public void Remove(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            using (U entityContext = new U())
            {
                T existingEntity = UpdateEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);

                entityContext.SaveChanges();
                return existingEntity;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (U entityContext = new U())
                return (GetEntities(entityContext)).ToArray().ToList();
        }

        public T Get(int id)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, id);
        }
    }
}
