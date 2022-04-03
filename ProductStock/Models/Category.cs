using System;
using System.ComponentModel.DataAnnotations;

namespace ProductStock.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must contain a maximum of 50 characters")]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
