using AutoMapper;

namespace Menu.Service.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DtoToDomainMapperProfile>();
                x.AddProfile<DomainToDtoMappingProfile>();
            });
        }
    }
}
