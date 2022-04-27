using System;
using System.ComponentModel.DataAnnotations;

namespace ProductStock.Data.Dtos
{
    public class ProductDto 
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must contain a maximum of 50 characters")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Descripton must contain a maximum of 150 characters")]
        public string Descripton { get; set; }

        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }

        [Required(ErrorMessage = "IdCategory is required")]
        public int IdCategory { get; set; }
    }
}
