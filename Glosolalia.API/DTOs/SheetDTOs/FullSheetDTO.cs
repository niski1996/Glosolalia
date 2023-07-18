using Glosolalia.API.DTOs.TranslationDTOs;
using Glosolalia.Common.Entities;

namespace Glosolalia.API.DTOs.SheetDTOs
{
    public class FullSheetDTO: CalcualtedSheetDTO
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastEdit { get; set; } = DateTime.Now;
        public List<TranslationDTO> TranslationSet { get; set; } = new(); 
    }
}
