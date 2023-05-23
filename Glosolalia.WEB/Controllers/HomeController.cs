using Glosolalia.Data;
using Glosolalia.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Glosolalia.WEB.Extensions;
using Glosolalia.WEB.Extensions;
using Glosolalia.Data.Contracts.Repository_Interface;

namespace Glosolalia.WEB.Controllers
{
	public class HomeController : Controller
	{
        private readonly ITranslationRepository _TranslationRepository;
        public HomeController(ITranslationRepository _translationRepository)
        {
            _TranslationRepository = _translationRepository ?? throw new ArgumentNullException(nameof(_TranslationRepository));
        }
        public IActionResult Index()
		{
            FlashCardsViewModel flsh = new FlashCardsViewModel(_TranslationRepository.GetAll());
            HttpContext.Session.Set("ActualFlashcards", flsh);
            return View();
		}
	}
}
