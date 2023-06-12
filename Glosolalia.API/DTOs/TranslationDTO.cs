using Glosolalia.Common.Entities;

namespace Glosolalia.API.DTOs
{
    public class TranslationDTO
    {
        public int Id { get; set; }
        public int Progress { get; set; }
        public string ValueWordOne { get; set; } = "";
        public string ValueWordTwo { get; set; } = "";
        public int LnaguageIdWordOne { get; set;}
        public int LanguageIdWordTwo { get; set; }

    }
}
