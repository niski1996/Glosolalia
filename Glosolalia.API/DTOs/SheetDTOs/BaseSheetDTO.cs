using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Glosolalia.API.DTOs.SheetDTOs
{
    public class BaseSheetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
