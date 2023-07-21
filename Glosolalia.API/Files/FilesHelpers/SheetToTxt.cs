using Glosolalia.API.DTOs.SheetDTOs;
using Glosolalia.API.DTOs.TranslationDTOs;

namespace Glosolalia.API.Files.FilesHelpers
{
    public static class SheetToTxt
    {
        private static readonly string _path = "../SheetTranslations.txt";
        public static void SaveToFile(FullSheetDTO sheet)
        {
            File.WriteAllText(_path, string.Empty);
            foreach (TranslationDTO item in sheet.TranslationSet) 
                {
                File.AppendText(item.ValueWordOne + "\t\t-\t\t" + item.ValueWordTwo + "\n");
                }
        }

    }
}
