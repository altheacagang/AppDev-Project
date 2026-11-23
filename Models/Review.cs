using System.ComponentModel.DataAnnotations;

namespace LaGilap.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required] public string StudentId { get; set; } = string.Empty;
        public ApplicationUser? Student { get; set; }

        public int StallId { get; set; }
        public Stall? Stall { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [Range(1, 5)] public int Rating { get; set; }
        [StringLength(500)] public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}