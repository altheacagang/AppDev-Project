using System.ComponentModel.DataAnnotations;
namespace LaGilap.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required, StringLength(50)] public string CategoryName { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
