using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductStock.Data;
using ProductStock.Data.Dtos;
using ProductStock.Models;

namespace ProductStock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private ProductStockContext _context;
        private IMapper _mapper;

        public OrderController(ProductStockContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Getorder()
        {
            return Ok(_context.Orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            Order order = _context.Orders.FirstOrDefault(order => order.Id == id);

            if (order != null)
            {
                return Ok(order);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);

            _context.Orders.Add(order);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrderById), new { Id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderDto orderDto)
        {
            Order order = _context.Orders.FirstOrDefault(order => order.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            _mapper.Map(orderDto, order);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            Order order = _context.Orders.FirstOrDefault(order => order.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Remove(order);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
