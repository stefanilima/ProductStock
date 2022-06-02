using System.ComponentModel.DataAnnotations;

namespace ProductStock.Models
{
    public class OrderProduct
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        public int IdOrder { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public int IdProduct { get; set; }
    }
}
