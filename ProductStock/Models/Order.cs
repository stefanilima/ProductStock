using System;
using System.ComponentModel.DataAnnotations;

namespace ProductStock.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdClient { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool Payment { get; set; }

        [Required(ErrorMessage = "IdPaymentType is required")]
        public int IdPaymentType { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public float Amount { get; set; }
    }
}
