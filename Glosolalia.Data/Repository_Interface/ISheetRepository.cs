
using Core.Common.Contracts;
using Glosolalia.Common.Entities;

namespace Glosolalia.Data.Repository_Interface
{
    public interface ISheetRepository : IDataRepository<Sheet>
    {
        public IEnumerable<Sheet> GetAll(bool WordIncluded, bool AllIncluded, GlosolaliaContext? context = null);
        public Sheet Get(int id, bool WordIncluded, bool AllIncluded);
        public IEnumerable<Translation> GetWords(int sheetId);
    }
}
