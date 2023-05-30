using Glosolalia.Common.Entities;
using Glosolalia.Common.Entities.DTOs.SheetDTOs;
using AutoMapper;

namespace Glosolalia.API.Profiles
{
    public class SheetProfile:Profile
    {
        public SheetProfile()
        {
            CreateMap<Sheet, SheetBaseInfoDto>();
        }
    }
}
