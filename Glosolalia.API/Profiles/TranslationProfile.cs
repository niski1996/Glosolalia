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
            CreateMap<Translation, TranslationForCreationDTO>();
            CreateMap<TranslationForCreationDTO, Translation>().
                ForMember(dest => dest.WordSet, opt => opt.MapFrom(src => new List<Word> {
                new Word(src.ValueWordOne,src.LanguageIdWordOne),
                new Word(src.ValueWordTwo,src.LanguageIdWordTwo)
                }
                )
                );
            var mapOne = CreateMap<Translation, TranslationDTO>();
            mapOne = mapOne.ForMember(dest => dest.ValueWordOne, opt => opt.MapFrom(src => src.WordSet[0].Value));
            mapOne = mapOne.ForMember(dest => dest.ValueWordTwo, opt => opt.MapFrom(src => src.WordSet[1].Value));
            mapOne = mapOne.ForMember(dest => dest.LanguageIdWordOne, opt => opt.MapFrom(src => src.WordSet[0].LanguageId));
            mapOne = mapOne.ForMember(dest => dest.LanguageIdWordTwo, opt => opt.MapFrom(src => src.WordSet[1].LanguageId));
        }
    }
}
