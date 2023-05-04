using Glosolalia.Data.Contracts.Repository_Interface;
using Microsoft.AspNetCore.Mvc;

namespace Glosolalia.WEB.Controllers
{
    public class EnWordsController:Controller
    {
        private readonly IEnWordRepository _enWordRepository;

        public EnWordsController(IEnWordRepository enWordRepository)
        {
            this._enWordRepository = enWordRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";

            //return View(_pieRepository.AllPies);

            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese cakes");
            return View(piesListViewModel);
        }
    }
}
