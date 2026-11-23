using System.ComponentModel.DataAnnotations;
namespace LaGilap.Models
{
    public class Product
    {
        public int ProductId {  get; set; }

        public int StallId {  get; set; }
        public Stall? Stall {  get; set; }
        
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required, StringLength(100)] public string ProductName { get; set; } =  string.Empty;
        [StringLength(300)] public string? Description {  get; set; }

        [Range(0.1,100000)] public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
