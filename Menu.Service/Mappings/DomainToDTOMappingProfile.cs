using AutoMapper;
using Menu.Contracts.DataContracts;
using Menu.Data;

namespace Menu.Service.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public new string ProfileName => "DomainToDtoMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<MenuItem, MenuItemData> ();
            Mapper.CreateMap<Category, CategoryData> ();
        }
    }
}