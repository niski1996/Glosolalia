using Glosolalia.Common.Entities;

namespace Glosolalia.API.DTOs.TranslationDTOs
{
    public class TranslationDTO
    {
        public int Id { get; set; }
        public int Progress { get; set; }
        public string ValueWordOne { get; set; } = "";
        public string ValueWordTwo { get; set; } = "";
        public int LanguageIdWordOne { get; set; }
        public int LanguageIdWordTwo { get; set; }

    }
}
