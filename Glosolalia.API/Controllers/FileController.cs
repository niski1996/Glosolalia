using Microsoft.AspNetCore.Mvc;

namespace Glosolalia.API.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
