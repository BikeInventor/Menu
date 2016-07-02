using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Menu.Client.Models
{
    public class CategoryViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastEdited { get; set; }

        public List<ItemViewModel> MenuItems { get; set; }
    }
}