using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace Glosolalia.Common.Entities
{
	[DataContract]
	public class Sheet : EntityBase, IIdentifiableEntity
	{
        public Sheet()/*ogólnie nie da rady go zrobić private, tylko dla EF core, bo może ono by dało radę,ale cała generyczność mi się psuje
                       * trzeba by przeprojektować całe repo
                        * 
                        * todo moze sheet powinien mieć language 1 i 2 i prywatny konstruktor dla ef core, a publiczny w którym sprawdza czy słowa są w językach, to 
			rozwiąże problem inputów i uniemożliwi tworzenie słów z złą ilościa słów a dodatkowo da opcje dla arkusza
			*/
        {
			Name = null!;//konstruktor tylko dla ef core, więc wyjebongo
			LanguageOne = null!;
			LanguageTwo = null!;
		}
        public Sheet(string name, int languageOneId, int languageTwoId, IEnumerable<Translation>? translations=null)
        {
			Name = name;
			if (languageOneId == languageTwoId)
			{
				throw new ApplicationException("Two languages cannot be the same");
			}
			else
			{
                LanguageOneId = languageOneId;
                LanguageTwoId = languageTwoId;
            }
			if (!(translations is null))
			{

				AddTranslation(translations);
			}
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
        public string Name { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now;
		public DateTime LastEdit { get; set; } = DateTime.Now;
		public List<Translation> TranslationSet { get; set; } = new(); /*ale na get dostaje referencje więc chój i tak każdy dostanie się do środka
		                                                               * musiałbym zwracać kopię, a nie mogę tego jebnąć na private,
		                                                               * bo ef core mi nie zmapuje
		                                                               */
		public Language LanguageOne { get; set; }
		public int LanguageOneId { get; set; }
        public Language LanguageTwo { get; set; }
        public int LanguageTwoId { get; set; }
		public IEnumerable<Translation> AddTranslation(Translation tran)
		{
			if (tran.WordSet.Count() != 2) throw new ApplicationException($"there are {tran.WordSet.Count()} in translation instead of 2");
			foreach (Word wrd in tran.WordSet)
			{
				if (!(wrd.LanguageId == LanguageOneId|| wrd.LanguageId == LanguageTwoId))// ewentualnie mogą być pobrane z db w różnym czasie wiec beda inne referencje
				{
                    throw new ApplicationException($"languages in translation doesn't fit to sheet languages");
                }
				TranslationSet.Add(tran);
			}
            return TranslationSet;
		}
        public IEnumerable<Translation> AddTranslation(IEnumerable<Translation> translationSet)
		{
			foreach (Translation trn in translationSet)
			{
				AddTranslation(trn);
			}
            return TranslationSet;
        }
    }


}