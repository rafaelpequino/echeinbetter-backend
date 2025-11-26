using System.ComponentModel.DataAnnotations;

namespace Echeinbetter.Dtos
{
    public class CreateInventoryDto
    {
        [Required(ErrorMessage = "Category is required")]
        [MaxLength(100, ErrorMessage = "Category cannot exceed 100 characters")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Product is required")]
        [MaxLength(200, ErrorMessage = "Product cannot exceed 200 characters")]
        public string Product { get; set; }

        [Required(ErrorMessage = "Batch is required")]
        [MaxLength(100, ErrorMessage = "Batch cannot exceed 100 characters")]
        public string Batch { get; set; }

        [Required(ErrorMessage = "Quad is required")]
        [MaxLength(50, ErrorMessage = "Quad cannot exceed 50 characters")]
        public string Quad { get; set; }

        [Required(ErrorMessage = "Bar code is required")]
        [MaxLength(100, ErrorMessage = "Bar code cannot exceed 100 characters")]
        public string BarCode { get; set; }

        [MaxLength(500, ErrorMessage = "Note cannot exceed 500 characters")]
        public string? Note { get; set; }
    }
}

