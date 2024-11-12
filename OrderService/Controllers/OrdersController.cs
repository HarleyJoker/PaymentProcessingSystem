using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using System.Collections.Generic;

namespace OrderService.Controllers
{   
    
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private static List<Order> orders = new List<Order>();

        //retrieves all orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(orders);
        }
        //creates a new order with "Pending" status
        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.OrderId = orders.Count + 1;
            order.Status = "Pending";
            orders.Add(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        //retrieves a specific order by ID 
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = orders.Find(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
