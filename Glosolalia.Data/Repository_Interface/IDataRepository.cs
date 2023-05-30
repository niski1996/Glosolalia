using Core.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data.Repository_Interface
{
    public interface IDataRepository<T>: IDataRepository<T, GlosolaliaContext>
        where T : class, IIdentifiableEntity, new()

    {
    }
}