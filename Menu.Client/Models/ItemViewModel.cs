using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menu.Client.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Amount { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public decimal Price { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastEdited { get; set; }

        public List<CategoryViewModel> Categories { get; set; }

    }
}