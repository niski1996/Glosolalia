using Glosolalia.Business.Entities;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business
{
	public class TranslationEngine
	{
		public void WordsAlone<SlaveLanguageType>(out SlaveLanguageType slaveWord, out List<PlWord> translations,
			string slaveValue, List<string> translationSet)
			where SlaveLanguageType: ITranslatable,IValue, new()
		{
			slaveWord = new SlaveLanguageType() { Value = slaveValue };
			translations =new List<PlWord>();

			foreach (string trans in translationSet)
			{
				PlWord translation = new PlWord(trans);
				translations.Add(translation);
			}
			foreach (PlWord word in translations)
			{
				slaveWord.TranslationAding(word);
			}


		}
	}
}