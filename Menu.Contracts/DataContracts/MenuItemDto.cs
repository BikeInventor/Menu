using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Menu.Contracts.DataContracts
{
    [DataContract(IsReference = true)]
    public class MenuItemDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime LastEdited { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Amount { get; set; }
        
        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<CategoryDto> Categories { get; set; } 
    }
}