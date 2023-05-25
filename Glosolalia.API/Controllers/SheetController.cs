using AutoMapper;
using Glosolalia.Common.Entities;
using Glosolalia.Common.Entities.DTOs.SheetDTOs;
using Glosolalia.Data.Contracts.Repository_Interface;
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
        public ActionResult<IEnumerable<SheetBaseInfoDto>> GetSheetSet()
        {
            var sheetEntities = _sheetRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<SheetBaseInfoDto>>(sheetEntities));

        }
    }
}
