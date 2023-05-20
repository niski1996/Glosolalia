using Microsoft.AspNetCore.Mvc;

namespace Glosolalia.WEB.Controllers
{
	public class WordListController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
