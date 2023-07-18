using Glosolalia.Common.Entities;
using AutoMapper;
using Glosolalia.API.DTOs.SheetDTOs;

namespace Glosolalia.API.Profiles
{
    public class SheetProfile : Profile
    {
        public SheetProfile()
        {
            CreateMap<Sheet, BaseSheetDTO>();
            _calculatedSheetMapping<CalcualtedSheetDTO>(CreateMap<Sheet, CalcualtedSheetDTO>());
            _calculatedSheetMapping<FullSheetDTO>(CreateMap<Sheet, FullSheetDTO>());
        }

        private IMappingExpression<Sheet, T> _calculatedSheetMapping<T>(IMappingExpression<Sheet, T> calcMap) where T : CalcualtedSheetDTO
        {
            calcMap = calcMap.ForMember(dest => dest.Begginer, opt => opt.MapFrom(src =>
                src.TranslationSet.Any() ? src.TranslationSet.Count(e => e.Progress <= 4) : 0));
            calcMap = calcMap.ForMember(dest => dest.Medium, opt => opt.MapFrom(src =>
                src.TranslationSet.Any() ? src.TranslationSet.Count(e => e.Progress > 4 && e.Progress < 8) : 0));
            calcMap = calcMap.ForMember(dest => dest.Pro, opt => opt.MapFrom(src =>
                src.TranslationSet.Any() ? src.TranslationSet.Count(e => e.Progress >= 8) : 0));
            calcMap = calcMap.ForMember(dest => dest.Points, opt => opt.MapFrom(src =>
                src.TranslationSet.Any() ? src.TranslationSet.Select(e => e.Progress).Sum() : 0));
            return calcMap;
        }
    }
}
