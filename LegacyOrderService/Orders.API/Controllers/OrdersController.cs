
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Ports;
using Orders.Domain.Entities;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrdersController(IOrderService service) => _service = service;

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetOrders());

        [HttpPost]
        public IActionResult Create(Order order)
        {
            try
            {
                _service.CreateOrder(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("GetTotal/{id}")]
        public IActionResult GetTotal(int id)
        {
            try
            {
                var order = _service.GetOrders().Where(t => t.Id == id).FirstOrDefault();
                return Ok(order.Quantity * order.Price);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
