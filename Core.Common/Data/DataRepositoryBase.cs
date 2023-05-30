using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Common.Contracts;
using Core.Common.Utils;
using Microsoft.EntityFrameworkCore;

namespace Core.Common.Data
{
    public abstract class DataRepositoryBase<T, U> : IDataRepository<T, U>
        where T : class, IIdentifiableEntity, new()
        where U : DbContext, new()
        /* wpuszczenie dodatkogo pola w metodach ktore odnosi sie to kontextu pozwoli to w miare ogarnąć 
         * a wyjebanie usingów i zastapienie ifami pozwoli wykorzystywać metody żeby nie musieć potem dodawać obiektów do trackingu
         * i nie robić burdelu z bazą*/
    {
        #region private and protected methods
        protected DbSet<T> _getDbSetFromContext(U entityContext)
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
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

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
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
        #endregion


        public T Add(T entity, U context = null)
        {
            U entityContext = context ?? new U();
            T addedEntity;
            try
            {
                addedEntity = AddEntity(entityContext, entity);
            }
            catch
            {
                throw;
            }
            finally
            {
                if ((entityContext != null) && (context is null))// is method is used as a proxy don't care, somaeoneelse close and sava
                {
                    entityContext.SaveChanges();
                    entityContext.Dispose();
                }
            }
            return addedEntity;
        }

        public void Remove(T entity, U context = null)
        {
            U entityContext = context ?? new U();
            using (entityContext)
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(int id, U context = null)
        {
            U entityContext = context ?? new U();
            using (entityContext)
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity, U context)
        {
            U entityContext = context ?? new U();
            using (entityContext)
            {
                T existingEntity = UpdateEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);

                entityContext.SaveChanges();
                return existingEntity;
            }
        }

        public IEnumerable<T> GetAll(U context = null)
        {
            U entityContext = context ?? new U();
            using (entityContext)
                return (GetEntities(entityContext)).ToArray().ToList();
        }

        public T Get(int id, U context = null)
        {
            U entityContext = context ?? new U();
            using (entityContext)
            {
                return GetEntity(entityContext, id);
            }
        }

    }
}