using AutoMapper;
using Glosolalia.API.DTOs.SheetDTOs;
using Glosolalia.API.DTOs.TranslationDTOs;
using Glosolalia.Common.Entities;

namespace Glosolalia.API.Profiles
{
    public class TranslationProfile: Profile
    {

        //calcMap = calcMap.ForMember(dest => dest.Begginer, opt => opt.MapFrom(src =>
        //        src.TranslationSet.Any()? src.TranslationSet.Count(e => e.Progress <= 4) : 0));
        //    calcMap
        public TranslationProfile()
        {
            var map = CreateMap<Translation, TranslationDTO>();
            map = map.ForMember(dest => dest.ValueWordOne, opt => opt.MapFrom(src => src.WordSet[0].Value));
            map = map.ForMember(dest => dest.ValueWordTwo, opt => opt.MapFrom(src => src.WordSet[1].Value));
            map = map.ForMember(dest => dest.LanguageIdWordOne, opt => opt.MapFrom(src => src.WordSet[0].LanguageId));
            map = map.ForMember(dest => dest.LanguageIdWordTwo, opt => opt.MapFrom(src => src.WordSet[1].LanguageId));
        }
    }
}
