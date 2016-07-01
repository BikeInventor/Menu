using System.Collections.Generic;
using Menu.Data.Core;

namespace Menu.Data
{
    public class MenuItem : DomainObject<int>
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public MenuItem()
        {
            Categories = new List<Category>();
        }

    }
}
