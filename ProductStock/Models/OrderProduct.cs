using System;
using System.ComponentModel.DataAnnotations;

namespace ProductStock.Models
{
    public class OrderProduct
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdOrder { get; set; }

        [Required]
        public int IdProdut { get; set; }
    }
}
