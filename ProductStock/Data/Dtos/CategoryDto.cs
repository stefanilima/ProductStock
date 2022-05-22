using System.ComponentModel.DataAnnotations;

namespace ProductStock.Data.Dtos
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must contain a maximum of 50 characters")]
        public string Name { get; set; }
    }
}
