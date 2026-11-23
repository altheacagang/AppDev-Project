namespace LaGilap.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string StudentId { get; set; } = string.Empty;
        public ApplicationUser? Student { get; set; }

        public int StallId { get; set; }
        public Stall? Stall { get; set; }

        public DateTime PickupTime { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Review? Review { get; set; }
    }
}