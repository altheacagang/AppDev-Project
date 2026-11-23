using System.ComponentModel.DataAnnotations;
namespace LaGilap.Models
{
    public class Stall
    {
        public int StallId { get; set; }

        [Required] public string OwnerId { get; set; } = string.Empty;
        public ApplicationUser? Owner { get; set; }

        [Required, StringLength(100)] public string StallName { get; set; } = string.Empty;
        [StringLength(500)] public string? Description {  get; set; } 

        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        [StringLength(250)] public string? Landmark { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Latag> Latags { get; set; } = new List<Latag>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
