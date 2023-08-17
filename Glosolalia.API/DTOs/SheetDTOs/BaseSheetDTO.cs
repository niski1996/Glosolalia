using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Glosolalia.API.DTOs.SheetDTOs
{
    public class BaseSheetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
    public class BaseSheetDTOValidator : AbstractValidator<BaseSheetDTO>
    {
        public BaseSheetDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty()
                .Matches(@"^\w*$")
                .WithMessage("Only alfanumeric signs are allowed");
        }
    }
}
