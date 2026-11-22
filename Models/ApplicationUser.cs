using Microsoft.AspNetCore.Identity;
namespace LaGilap.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Fullname { get; set; } = string.Empty;
        public string? ContactNumber {  get; set; }
        public string? Address {  get; set; }
    }
}
