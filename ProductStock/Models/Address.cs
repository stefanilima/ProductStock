using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductStock.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, ErrorMessage = "Country must contain a maximum of 50 characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(50, ErrorMessage = "Street must contain a maximum of 50 characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }

        [JsonIgnore]
        public virtual Client Client { get; set; }
    }
}
