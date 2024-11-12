using Microsoft.AspNetCore.Mvc;
using PaymentService.Models;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private static List<Payment> payments = new List<Payment>();

        //Processes a payment (simulated as successful)
        [HttpPost]
        public ActionResult<Payment> ProcessPayment(Payment payment)
        {
            payment.PaymentId = payments.Count + 1;
            payment.Status = "Successful"; // In a real app, I  have to  implement actual payment processing logic
            payment.ProcessedAt = DateTime.UtcNow;
            payments.Add(payment);
            return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, payment);
        }

        //retrieves a specific payment by ID 
        [HttpGet("{id}")]
        public ActionResult<Payment> GetPayment(int id)
        {
            var payment = payments.Find(p => p.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

    }
}
