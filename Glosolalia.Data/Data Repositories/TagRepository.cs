using System.ComponentModel.Composition;
using Glosolalia.Business.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;

namespace Glosolalia.Data
{
    [Export(typeof(ITagRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TagRepository : DataRepositoryBase<Tag>, ITagRepository
    {
    }

}
