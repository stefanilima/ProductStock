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
    public class OrderProductController : ControllerBase
    {
        private ProductStockContext _context;
        private IMapper _mapper;

        public OrderProductController(ProductStockContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrderProduct()
        {
            return Ok(_context.OrderProducts);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderProductById(int id)
        {
            OrderProduct orderProduct = _context.OrderProducts.FirstOrDefault(orderProduct => orderProduct.Id == id);

            if (orderProduct != null)
            {
                return Ok(orderProduct);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateOrderProduct([FromBody] OrderProductDto orderProductDto)
        {
            OrderProduct orderProduct = _mapper.Map<OrderProduct>(orderProductDto);

            _context.OrderProducts.Add(orderProduct);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrderProductById), new { Id = orderProduct.Id }, orderProduct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderProduct(int id, [FromBody] OrderProductDto orderProductDto)
        {
            OrderProduct orderProduct = _context.OrderProducts.FirstOrDefault(order => order.Id == id);

            if (orderProduct == null)
            {
                return NotFound();
            }

            _mapper.Map(orderProductDto, orderProduct);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderProduct(int id)
        {
            OrderProduct orderProduct = _context.OrderProducts.FirstOrDefault(orderProduct => orderProduct.Id == id);

            if (orderProduct == null)
            {
                return NotFound();
            }

            _context.Remove(orderProduct);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
