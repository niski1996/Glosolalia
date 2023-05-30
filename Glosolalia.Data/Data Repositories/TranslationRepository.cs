using System.ComponentModel.Composition;

using Glosolalia.Common.Entities;
using Glosolalia.Data.Repository_Interface;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data
{
	[Export(typeof(ITranslationRepository))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class TranslationRepository : DataRepositoryBase<Translation>, ITranslationRepository
	/*wlasciwie to wydaje mi się że na ten moment słowa powinny być tworzone tylko w tłumaczeniach i razem z nimi usuwane,
	 * bo jest włąściewie bez sensu mieć puste słowo bez tłumaczenia.
	 * Trzebaby sptrwdzić co się stanie jak usunę , czy pójdzie kaskada*/
	{
        protected override Translation AddEntity(GlosolaliaContext entityContext, Translation entity)
        {
			var wrd = new WordRepository();
			for (int i = 0; i < entity.WordSet.Count(); i++)
			{
				entity.WordSet[i] = wrd.Add(entity.WordSet[i], entityContext);
			}
			List<int> idList = entity.WordSet.Select(e => e.Id).ToList();
			var tmp = entityContext.TranslationSet.Where(a => a.WordSet.Any(b => idList.Contains(b.Id))).FirstOrDefault();// sprawdza czy taka translacja już istnieje
            if (tmp != null) { return tmp; }
            return entityContext.TranslationSet.Add(entity).Entity;


        }
	}
}

