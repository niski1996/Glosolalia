using System.ComponentModel.Composition;
using System.Net;
using Glosolalia.Common.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data
{
    [Export(typeof(ISheetRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SheetRepository : DataRepositoryBase<Sheet>, ISheetRepository
    {
        public IEnumerable<Translation> GetWords(int sheetId)
        {
            using (GlosolaliaContext entityContext = new())
            {

                var tmp = entityContext.SheetSet.Include(e => e.TranslationSet)
                    .FirstOrDefault(e => e.Id == sheetId);
                return tmp.TranslationSet;//Hack,co jak bedzie pusta
            }
        }
    }

}
