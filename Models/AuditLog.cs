using System.ComponentModel.DataAnnotations;

namespace LaGilap.Models
{
    public class AuditLog
    {
        [Key] public int AuditId { get; set; }

        [Required] public string AdminId { get; set; } = string.Empty;
        public ApplicationUser? Admin { get; set; }

        [Required, StringLength(100)] public string Action { get; set; } = string.Empty;
        public string? TargetUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}