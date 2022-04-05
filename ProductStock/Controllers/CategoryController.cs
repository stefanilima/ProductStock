using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductStock.Data;
using ProductStock.Models;

namespace ProductStock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private ProductStockContext _context;

        public CategoryController(ProductStockContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(_context.Categorys);
        }

        [HttpPost("{id}")]
        public IActionResult getCategoryById(int id)
        {
            Category category = _context.Categorys.FirstOrDefault(category => category.Id == id);

            if(category != null)
            {
                return Ok(category);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            _context.Categorys.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(getCategoryById), new { Id = category.Id }, category );
        }

        [HttpDelete]
        public void DeleteCategory()
        {

        }
    }
}
