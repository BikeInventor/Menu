using AutoMapper;
using Menu.Contracts.DataContracts;
using Menu.Data;

namespace Menu.Service.Mappings
{
    public class DtoToDomainMapperProfile : Profile
    {
        public new string ProfileName => "DtoToDomainMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<MenuItemData, MenuItem>();
        }
    }
}