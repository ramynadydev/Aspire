using AspireApp1.ServiceDefaults.Model;
using AspireApp1.ServiceDefaults.Service;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.ApiService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            order.CreatedAt = DateTime.UtcNow;
            var createdOrder = await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(CreateOrder), new { id = createdOrder.Id }, createdOrder);
        }
    }

}
