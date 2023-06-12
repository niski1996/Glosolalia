using System.ComponentModel.Composition;
using System.Net;
using Glosolalia.Common.Entities;
using Glosolalia.Data.Repository_Interface;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data
{
    [Export(typeof(ISheetRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SheetRepository : DataRepositoryBase<Sheet>, ISheetRepository
    {
        protected override Sheet AddEntity(GlosolaliaContext entityContext, Sheet entity)
        {
            var trn = new TranslationRepository();
            for (int i = 0; i < entity.TranslationSet.Count(); i++)
            {
                entity.TranslationSet[i] = trn.Add(entity.TranslationSet[i], entityContext);
            }
            return entityContext.SheetSet.Add(entity).Entity;


        }

        public IEnumerable<Sheet> GetAll(bool WordIncluded, bool AllIncluded,GlosolaliaContext? context = null)
        {
            using (GlosolaliaContext entityContext = new())
            {
                if (AllIncluded)
                    return entityContext.SheetSet.Include(e => e.TranslationSet).ThenInclude(e=>e.WordSet).ToList();
                else if (WordIncluded)
                {
                    return entityContext.SheetSet.Include(e => e.TranslationSet).
                        ThenInclude(e => e.WordSet).ThenInclude(e=>e.Language).
                        ToList();
                }
            }
            return base.GetAll(context);
        }

        public IEnumerable<Translation> GetWords(int sheetId)
        {
            using (GlosolaliaContext entityContext = new())
            {
                var tmp = entityContext.SheetSet.Include(e => e.TranslationSet)
                    .FirstOrDefault(e => e.Id == sheetId);
                return tmp.TranslationSet;//Hack,co jak bedzie pusta
            }
        }
        public Sheet Get(int id, bool WordIncluded, bool AllIncluded)
        {
            using (GlosolaliaContext entityContext = new())
            {
                if (AllIncluded)
                    return entityContext.SheetSet.Include(e => e.TranslationSet).ThenInclude(e => e.WordSet).Where(e => e.Id == id).FirstOrDefault();
                else if (WordIncluded)
                {
                    return entityContext.SheetSet.Include(e => e.TranslationSet).ThenInclude(e => e.WordSet).Where(e => e.Id == id).FirstOrDefault();
                }
            }
            return base.Get(id);
        }

    }

}
