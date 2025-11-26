using System.ComponentModel.DataAnnotations;

namespace Echeinbetter.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [MaxLength(200)]
        public string Product { get; set; }

        [MaxLength(100)]
        public string Batch { get; set; }

        [MaxLength(50)]
        public string Quad { get; set; }

        [MaxLength(100)]
        public string BarCode { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }
    }
}

