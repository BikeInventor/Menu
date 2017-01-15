using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Menu.Contracts.DataContracts
{
    [DataContract(IsReference = true)]
    public class CategoryDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime LastEdited { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<MenuItemDto> MenuItems { get; set; } 
    }
}
