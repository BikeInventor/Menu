using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Menu.Contracts.DataContracts
{
    [DataContract]
    public class MenuItemData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Amount { get; set; }
        
        [DataMember]
        public decimal Price { get; set; }
    }
}