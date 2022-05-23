using System.ComponentModel.DataAnnotations;

namespace ProductStock.Data.Dtos
{
    public class OrderProductDto
    {
        [Required]
        public int IdOrder { get; set; }

        [Required]
        public int IdProduct { get; set; }
    }
}
