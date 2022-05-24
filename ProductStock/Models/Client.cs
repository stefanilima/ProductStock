using System;
using System.ComponentModel.DataAnnotations;

namespace ProductStock.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must contain a maximum of 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "Email must contain a maximum of 100 characters")]
        public string Email { get; set; }

        public Address Address { get; set; }

        public int IdAddress { get; set; }
    }
}
