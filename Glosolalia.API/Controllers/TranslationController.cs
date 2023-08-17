using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<TranslationForCreationDTO> _creationValidator;
        public TranslationsController(ITranslationRepository translationRepository, IMapper mapper, IValidator<TranslationForCreationDTO> validator)
        {
            this._mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            this._translationRepository = translationRepository ??
                throw new ArgumentException(nameof(translationRepository));
            this._creationValidator =validator ??
                throw new ArgumentNullException(nameof(validator));
        }
        [HttpGet]
        public ActionResult<List<TranslationDTO>> GetAll()
        {
            return Ok(_mapper.Map<List<TranslationDTO>>(_translationRepository.GetAll()));
        }

        [HttpGet("{id}", Name = "GetTranslation")]
        public ActionResult<TranslationDTO> Get(int id)
        {
            TranslationDTO? trans = _mapper.Map<TranslationDTO>(_translationRepository.Get(id));
            return trans == null ? NotFound(): Ok(trans);
        }
        [HttpPost]
        public ActionResult<TranslationDTO> CreateTranslation(TranslationForCreationDTO translationForCreationDTO)
        {
            var validationResult = _creationValidator.Validate(translationForCreationDTO);
            if (validationResult.IsValid)
            {
                var tmp = _translationRepository.Add(_mapper.Map<Translation>(translationForCreationDTO));
                return CreatedAtRoute("GetTranslation",
                    new
                    {
                        id = tmp.Id
                    },
                    _mapper.Map<TranslationDTO>(tmp));
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }
                return BadRequest();
            }
             
        }


    }
}
