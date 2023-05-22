
using Core.Common.Contracts;
using Glosolalia.Common.Entities;

namespace Glosolalia.Data.Contracts.Repository_Interface
{
    public interface ISheetRepository : IDataRepository<Sheet>
    {
        public IEnumerable<Translation> GetWords(int sheetId);
    }
}
