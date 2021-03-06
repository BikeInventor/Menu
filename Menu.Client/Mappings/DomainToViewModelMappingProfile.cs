﻿using AutoMapper;
using Menu.Client.Models;
using Menu.Contracts.DataContracts;

namespace Menu.Client.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public new string ProfileName => "DomainToViewModelMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<MenuItemDto, ItemViewModel>();
            Mapper.CreateMap<CategoryDto, CategoryViewModel>();

            Mapper.CreateMap<NotFoundException, ErrorViewModel>();
        }
    }
}