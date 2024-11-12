﻿namespace PaymentService.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // e.g., "Successful", "Failed"
        public DateTime ProcessedAt { get; set; }
    }
}
