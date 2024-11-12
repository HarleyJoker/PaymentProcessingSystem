namespace OrderService.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Paid", "Cancelled"
    }
}
