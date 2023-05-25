using Microsoft.EntityFrameworkCore;

namespace Core.Common.Contracts
{
    public interface IDataRepository
    {

    }
    public interface IDataRepository<T, U>: IDataRepository
        where T : class,IIdentifiableEntity,new()
        where U : DbContext, new()
    {
        T Add(T entity, U context=null);
        void Remove(T entity, U context=null);
        void Remove(int id, U context=null);
        T Update(T entity, U context=null);
        IEnumerable<T> GetAll(U context=null);
        T Get(int id,U context=null);
    }

}