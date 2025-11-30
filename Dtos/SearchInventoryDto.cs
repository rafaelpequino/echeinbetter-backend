using System.ComponentModel.DataAnnotations;

namespace Echeinbetter.Dtos
{
    public class SearchInventoryDto
    {
        [MaxLength(100, ErrorMessage = "Bar code cannot exceed 100 characters")]
        public string? BarCode { get; set; }
    }
}


