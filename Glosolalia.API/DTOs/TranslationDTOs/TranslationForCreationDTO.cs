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
}
