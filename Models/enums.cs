namespace LaGilap.Models
{
    public enum VerificationStatus { Pending, Approved, Rejected }
    public  enum OrderStatus
    {
        Pending, Confirmed, Preparing, ReadyForPickup, 
        Completed, Rejected, Cancelled, NoShow
    }
}
