using Glosolalia.Common.Entities;
using AutoMapper;
using Glosolalia.API.DTOs.SheetDTOs;

namespace Glosolalia.API.Profiles
{
    public class SheetProfile:Profile
    {
        public SheetProfile()
        {
            CreateMap<Sheet, BaseSheetDTO>();
            var calcMap = CreateMap<Sheet, CalcualtedSheetDTO>();
            calcMap = calcMap.ForMember(dest => dest.Begginer, opt => opt.MapFrom(src =>
                src.TranslationSet.Any() ? src.TranslationSet.Count(e => e.Progress <= 4) : 0));
            calcMap = calcMap.ForMember(dest => dest.Medium, opt => opt.MapFrom(src =>
                src.TranslationSet.Any() ? src.TranslationSet.Count(e => e.Progress > 4 && e.Progress < 8) : 0));
            calcMap = calcMap.ForMember(dest => dest.Pro, opt => opt.MapFrom(src =>
                src.TranslationSet.Any() ? src.TranslationSet.Count(e => e.Progress >= 8) : 0));
            calcMap = calcMap.ForMember(dest => dest.Points, opt => opt.MapFrom(src =>
                src.TranslationSet.Any() ? src.TranslationSet.Select(e => e.Progress).Sum() : 0));
        //    calcMap = calcMap.ForMember(dest => dest.LanguageOne, opt => opt.MapFrom(src =>
        //src.TranslationSet.Any() ? src.TranslationSet[0].WordSet[0].Language.Name : null));
    //.ForMember(dest => dest.LanguageTwo, opt => opt.MapFrom(src =>
    //    src.TranslationSet.Any() && src.TranslationSet[0].WordSet.Count > 1
    //        ? src.TranslationSet[0].WordSet[1].Language
    //        : null));
    //CreateMap<Sheet, CalcualtedSheetDTO>().
    //    ForMember(dest=>dest.Begginer, opt=>opt.MapFrom(// co jesli arkusz nie ma tłumaczeń??
    //        src=>src.TranslationSet.Where(e=>e.Progress<=4).Count())).

            //        ForMember(dest => dest.Medium, opt => opt.MapFrom(
            //        src => src.TranslationSet.Where(e => ((e.Progress > 4)&&(e.Progress<8))).Count())).

            //        ForMember(dest => dest.Pro, opt => opt.MapFrom(
            //        src => src.TranslationSet.Where(e => e.Progress >=8).Count())).

            //        ForMember(dest => dest.Points, opt => opt.MapFrom(
            //        src => src.TranslationSet.Select(e=>e.Progress).Sum())).

            //        ForMember(dest=>dest.LanguageOne, opt => opt.MapFrom(
            //        src => src.TranslationSet[0].WordSet[0].Language)).

            //        ForMember(dest => dest.LanguageOne, opt => opt.MapFrom(
            //        src => src.TranslationSet[0].WordSet[1].Language))//TODO tu mogą być, i pewnie będą błędy jezeli mam 1 słowo, albo 0 słów
            //        ;

        }
    }
    
}
