using Glosolalia.Data;
using Glosolalia.WEB.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Glosolalia.WEB.Extensions;

namespace Glosolalia.WEB.Controllers
{
	public class FlashcardsShowController : Controller
	{
        public IActionResult ShowFlashcards()
        {
            return View(HttpContext.Session.Get<FlashCardsViewModel>("ActualFlashcards"));
        }

    }
}


