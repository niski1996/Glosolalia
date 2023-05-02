using Core.Common.Contracts;
using Core.Common.Data;

namespace Glosolalia.Data
{

    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, GlosolaliaContext>
        where T : class, IIdentifiableEntity, new()

    {
    }
}
