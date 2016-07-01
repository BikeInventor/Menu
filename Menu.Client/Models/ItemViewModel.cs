using System;

namespace Menu.Client.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Amount { get; set; }

        public decimal Price { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastEdited { get; set; }

    }
}