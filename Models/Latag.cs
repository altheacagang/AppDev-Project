using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LaGilap.Models
{
    public class Latag
    {
        public int LatagId { get; set; }

        public int StallId { get; set; }
        public Stall? Stall { get; set; }

        [Required] public string PostedById { get; set; } = string.Empty;
        public ApplicationUser? PostedBy { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        [Required, StringLength(100) ] public string Title { get; set; } = string.Empty;
        [StringLength(500)] public string? Description { get; set; }
        public decimal? Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }


    }
}
