using FluentValidation;

namespace Glosolalia.API.DTOs.TranslationDTOs
{
    public class TranslationForCreationDTO
    {
        public int Progress { get; set; } = 0;
        public string ValueWordOne { get; set; } = "";
        public string ValueWordTwo { get; set; } = "";
        public int LanguageIdWordOne { get; set; }
        public int LanguageIdWordTwo { get; set; }
    }
    public class TranslationForCreationDTOValidator : AbstractValidator<TranslationForCreationDTO>
    {
        public TranslationForCreationDTOValidator()
        {
            RuleFor(x => x.ValueWordOne).NotEmpty().Matches(@"^\w*$").WithMessage("Word value must be not empty, alphanumeric");
            RuleFor(x => x.ValueWordTwo).NotEmpty().Matches(@"^\w*$").WithMessage("Word value must be not empty, alphanumeric");
        }
    }
}
