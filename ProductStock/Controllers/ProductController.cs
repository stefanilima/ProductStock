using System.Collections.Generic;
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
    public class ProductController : ControllerBase
    {
        private ProductStockContext _context;
        private IMapper _mapper;

        public ProductController(ProductStockContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProduct([FromQuery] int? quantity = null)
        {
            List<Product> products;

            if (quantity == null)
            {
                products = _context.Products.ToList();
            } else
            {
                products = _context.Products.Where(product => product.Quantity <= quantity).ToList();
            }

            if(products != null)
            {
                return Ok(products);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == id);

            if(product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProductById), new { Id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _mapper.Map(productDto, product);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
