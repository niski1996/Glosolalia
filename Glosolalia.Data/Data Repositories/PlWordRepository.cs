using System.ComponentModel.Composition;
using Glosolalia.Business.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;

namespace Glosolalia.Data
{
    [Export(typeof(IPlWordRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlWordRepository : DataRepositoryBase<PlWord>, IPlWordRepository
    {
    }

}
