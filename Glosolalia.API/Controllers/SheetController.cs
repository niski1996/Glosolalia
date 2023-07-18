using AutoMapper;
using Glosolalia.API.DTOs.SheetDTOs;
using Glosolalia.Common.Entities;
using Glosolalia.Data.Repository_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Glosolalia.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SheetController : ControllerBase
    {
        private readonly ISheetRepository _sheetRepository;
        private readonly IMapper _mapper;
        public SheetController(ISheetRepository sheetRepository, IMapper mapper)
        {
            this._mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            this._sheetRepository = sheetRepository ??
                throw new ArgumentException(nameof(sheetRepository));
        }
        [HttpGet]
        public ActionResult GetSheetSet(int? languageId, string name = "", string type = "base")
        {
            IEnumerable<Sheet> sheetSet;
            switch (type)
            {
                case "calculated":
                    sheetSet = _sheetRepository.GetAll(true, false);
                    break;
                default:
                    sheetSet = _sheetRepository.GetAll();
                    break;
            }
            sheetSet = sheetSet.Where(e =>e.Name.ToLower().Contains(name.ToLower())).
                Where(e => ((languageId == null ? 0 : languageId) == (languageId == null ? 0 : e.LanguageOneId)) ||
                ((languageId == null ? 0 : languageId) == (languageId == null ? 0 : e.LanguageTwoId)));

            switch (type)
            {
                
                case "base":
                    return Ok(_mapper.Map<IEnumerable<BaseSheetDTO>>(sheetSet));
                case "calculated":
                        return Ok(_mapper.Map<IEnumerable<CalcualtedSheetDTO>>(sheetSet));
                default:
                    return Ok(_mapper.Map<IEnumerable<BaseSheetDTO>>(sheetSet));
            }

        }
        [HttpGet("{id}")]
        public ActionResult GetSheet(int id, string type = "base")
        {
            switch (type)
            {

                case "base":
                    return Ok(_mapper.Map<BaseSheetDTO>(_sheetRepository.Get(id)));
                case "calculated":
                    return Ok(_mapper.Map<CalcualtedSheetDTO>(_sheetRepository.Get(id,true, false)));
                case "full":
                    return Ok(_mapper.Map<FullSheetDTO>(_sheetRepository.Get(id, false, true)));
                default:
                    return Ok(_mapper.Map<BaseSheetDTO>(_sheetRepository.Get(id)));
            }

        }
        //[HttpGet("{id})")]
        //public IActionResult GetSheet(int sheetId,bool includeTranslations = false)
        //{ 
        //    //var Sheet = 
        //}
    }
}
