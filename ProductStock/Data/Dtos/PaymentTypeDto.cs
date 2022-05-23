using System.ComponentModel.DataAnnotations;

namespace ProductStock.Data.Dtos
{
    public class PaymentTypeDto
    {
        [Required(ErrorMessage = "Payment is required")]
        [StringLength(20, ErrorMessage = "Payment must contain a maximum of 20 characters")]
        public string Payment { get; set; }

        public int Split { get; set; }
    }
}
