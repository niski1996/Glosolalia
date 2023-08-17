using FluentValidation;
using Glosolalia.Common.Entities;

namespace Glosolalia.API.DTOs.SheetDTOs
{
    public class CalcualtedSheetDTO:BaseSheetDTO
    {
        public int Begginer { get; set; }
        public int Medium { get; set; }
        public int Pro { get; set; }
        public int Points { get; set; }
        public int LanguageOneId { get; set; }
        public int LanguageTwoId { get; set; }
        public int TranslationAmount { get 
            {
                return Begginer + Medium + Pro;
            } }
        public float Progress
        {
            get
            {
                try
                {
                    return (Points / (10 * TranslationAmount));
                }
                catch (DivideByZeroException)
                {

                    return 0;
                }
                
            }
        }
    }
    public class CalcualtedSheetDTOValidator : AbstractValidator<CalcualtedSheetDTO>
    {
        public CalcualtedSheetDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty()
                .Matches(@"^\w*$")
                .WithMessage("Only alfanumeric signs are allowed");
            RuleFor(x=>x.Medium).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.Progress).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.Begginer).NotEmpty().GreaterThan(0);

        }
    }
}
