using Glosolalia.Data;
using Glosolalia.Data.Contracts.Repository_Interface;
using Glosolalia.WEB.ViewModels;
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

            //EnWordListViewModel enWordSetListViewModel = new EnWordListViewModel(_enWordRepository.GetAll());
            ViewBag.Prompt = "Welcome";
            return View(_enWordRepository.GetAll());
        }
    }
}
