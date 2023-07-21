using AutoMapper;
using Glosolalia.API.DTOs.SheetDTOs;
using Glosolalia.API.DTOs.TranslationDTOs;
using Glosolalia.Data;
using Glosolalia.Data.Repository_Interface;
using Microsoft.AspNetCore.Mvc;

namespace Glosolalia.API.Controllers
{
    [Route("api/Sheet/{SheetId}/translations")]
    [ApiController]
    public class TranslationInSheetController : Controller
    {
        private readonly ISheetRepository _sheetRepository;
        private readonly IMapper _mapper;
        public TranslationInSheetController(ISheetRepository sheetRepository, IMapper mapper)
        {
            this._mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            this._sheetRepository = sheetRepository ??
                throw new ArgumentException(nameof(sheetRepository));
        }
        //[HttpGet]
        //public ActionResult<List<TranslationDTO>> GetTranslationFromSheet(int SheetId)
        //{
        //    var fullSheet = _mapper.Map<FullSheetDTO>(_sheetRepository.Get(SheetId, false, true));
        //    return fullSheet is null ? NotFound() : Ok(fullSheet.TranslationSet);
        //}

    }
}
