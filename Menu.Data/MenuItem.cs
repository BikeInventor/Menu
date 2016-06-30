using System;
using Menu.Data.Core;

namespace Menu.Data
{
    public class MenuItem : DomainObject<int>
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public decimal Price { get; set; }

        public MenuItem()
        {
            this.Created = DateTime.Now;
            this.LastEdited = DateTime.Now;
        }
    }
}
