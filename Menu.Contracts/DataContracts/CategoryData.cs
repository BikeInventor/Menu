using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Contracts.DataContracts
{
    [DataContract(IsReference = true)]
    public class CategoryData
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
        public List<MenuItemData> MenuItems { get; set; } 
    }
}
