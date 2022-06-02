using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductStock.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must contain a maximum of 50 characters")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Descripton must contain a maximum of 150 characters")]
        public string Descripton { get; set; }

        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [StringLength(10, ErrorMessage = "Price must contain a maximum of 10 characters")]
        public float Price { get; set; }

        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "IdCategory is required")]
        public int IdCategory { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
