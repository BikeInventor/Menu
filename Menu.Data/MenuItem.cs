﻿using Menu.Data.Core;

namespace Menu.Data
{
    public class MenuItem : DomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public decimal Price { get; set; }
    }
}
