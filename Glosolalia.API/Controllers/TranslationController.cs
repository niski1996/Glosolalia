using AutoMapper;
using Glosolalia.API.DTOs.SheetDTOs;
using Glosolalia.API.DTOs.TranslationDTOs;
using Glosolalia.Common.Entities;
using Glosolalia.Data;
using Glosolalia.Data.Repository_Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Glosolalia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        private readonly ITranslationRepository _translationRepository;
        private readonly IMapper _mapper;
        public TranslationsController(ITranslationRepository translationRepository, IMapper mapper)
        {
            this._mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            this._translationRepository = translationRepository ??
                throw new ArgumentException(nameof(translationRepository));
        }
        [HttpGet]
        public ActionResult<List<TranslationDTO>> GetAll()
        {
            return Ok(_mapper.Map<List<TranslationDTO>>(_translationRepository.GetAll()));
        }

        [HttpGet("{id}", Name = "GetTranslation")]
        public ActionResult<TranslationDTO> Get(int id)
        {
            return Ok(_mapper.Map<TranslationDTO> (_translationRepository.Get(id)));
        }
        [HttpPost]
        public ActionResult<TranslationDTO> CreateTranslation(TranslationForCreationDTO translationForCreationDTO)
        {
            var tmp = _translationRepository.Add(_mapper.Map<Translation>(translationForCreationDTO));
            return CreatedAtRoute("GetTranslation",
                new
                {
                    id = tmp.Id
                });
             
        }


    }
}
