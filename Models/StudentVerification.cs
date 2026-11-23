using System.ComponentModel.DataAnnotations;

namespace LaGilap.Models
{
    public class StudentVerification
    {
        [Key] public int VerificationId { get; set; }

        [Required] public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        [Required, StringLength(30)] public string StudentIdNumber { get; set; } = string.Empty;
        [Required, StringLength(300)] public string IdImagePath { get; set; } = string.Empty;

        public VerificationStatus Status { get; set; } = VerificationStatus.Pending;
        [StringLength(300)] public string? RejectionReason { get; set; }

        public string? ReviewedById { get; set; }
        public ApplicationUser? ReviewedBy { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReviewedAt { get; set; }
    }
}