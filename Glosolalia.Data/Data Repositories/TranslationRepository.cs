using System.ComponentModel.Composition;

using Glosolalia.Common.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data
{
	/*wlasciwie to wydaje mi się że na ten moment słowa powinny być tworzone tylko w tłumaczeniach i razem z nimi usuwane,
	 * bo jest włąściewie bez sensu mieć puste słowo bez tłumaczenia.
	 * Trzebaby sptrwdzić co się stanie jak usunę , czy pujdzie kaskada*/
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class TranslationRepository : DataRepositoryBase<Translation> 
	{
		private void _addWordsToTrackingIfExisting(GlosolaliaContext context,List<Word> wordSet)// ref jest,bo lista jest edydaowana,żeby nie było zdziwienia potem
		{
			for (int i = 0; i < wordSet.Count(); i++)
			{
				if (wordSet[i].Id!=0)
				{
					context.Words.Find(wordSet[i].Id);
				}
				else
				{
					Word checkedWord = wordSet[i];
					Word existWord = context.Words.FirstOrDefault(
						e => (
						(e.Value == checkedWord.Value)
						& (e.LanguageId == checkedWord.LanguageId)
						));
					if (existWord != null) { wordSet[i] = existWord;  }
				}
			}
		}
		public void AddRelationalTranslation(Translation entity)
			/*REFA|CTOR method used to create translation,when relations many-to-many are not empty
			 * creating with nomal add cause problems, cause i create new context every time, wchat mean that scope is empyt
			 * so ef core doesn't tracka any objects and tried to create everythink
			 * NOTE bugs may hapend here fi ef core go deeper in relative graph*/
		{
			using (GlosolaliaContext entityContext = new ())
			{
				_addWordsToTrackingIfExisting(entityContext,entity.TranslatableSet);
				Translation addedEntity = AddEntity(entityContext, entity);

				entityContext.SaveChanges();
				return;
			}
		}
	}


}
