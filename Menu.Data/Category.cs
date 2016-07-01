using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Data.Core;

namespace Menu.Data
{
    public class Category : DomainObject<long>
    {
        public string Name { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }

        public Category()
        {
            MenuItems = new List<MenuItem>();
        }
    }
}
