using Glosolalia.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Glosolalia.API.DTOs.SheetDTOs
{
    public class SheetForCreationDTO
    {


        [Required]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastEdit { get; set; } = DateTime.Now;
        public List<Translation> TranslationSet { get; set; } = new(); /*ale na get dostaje referencje więc chój i tak każdy dostanie się do środka
		                                                               * musiałbym zwracać kopię, a nie mogę tego jebnąć na private,
		                                                               * bo ef core mi nie zmapuje
		                                                               */
        public Language LanguageOne { get; set; }
        public int LanguageOneId { get; set; }
        public Language LanguageTwo { get; set; }
        public int LanguageTwoId { get; set; }

}
}
