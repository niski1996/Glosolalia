using Glosolalia.Common.Entities;
using Glosolalia.Data;
using Glosolalia.Data.Contracts.Repository_Interface;
using Microsoft.AspNetCore.Mvc;

namespace Glosolalia.WEB.Controllers
{
	public class WordListController : Controller
	{
		private readonly ITranslationRepository _TranslationRepository;
        public WordListController(ITranslationRepository _translationRepository)
        {
            _TranslationRepository= _translationRepository ?? throw new ArgumentNullException(nameof(_TranslationRepository));
        }
        public IActionResult AllWordsInLanguageList()
		{
			//WordsInLanguageListViewModel wordsInLanguageListViewModel=new WordsInLanguageListViewModel(_TranslationRepository.GetAll())


			return View(_TranslationRepository.GetAll());
		}
	}

	//internal class WordsInLanguageListViewModel
	//{
	//	private IEnumerable<Translation> enumerable;

	//	public WordsInLanguageListViewModel()//IEnumerable<Translation> enumerable)
	//	{
	//		this.enumerable = enumerable;
	//	}
	//}
}
