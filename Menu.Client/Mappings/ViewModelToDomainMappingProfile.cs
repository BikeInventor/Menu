using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Menu.Client.Models;
using Menu.Contracts.DataContracts;

namespace Menu.Client.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public new string ProfileName => "ViewModelToDomainMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<ItemViewModel, MenuItemData>();          
        }
    }
}