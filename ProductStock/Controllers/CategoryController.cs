using System;
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
    public class CategoryController : ControllerBase
    {
        private ProductStockContext _context;
        private IMapper _mapper;

        public CategoryController(ProductStockContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(_context.Categorys);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = _context.Categorys.FirstOrDefault(category => category.Id == id);

            if(category != null)
            {
                return Ok(category);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);

            _context.Categorys.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategoryById), new { Id = category.Id }, category );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            Category category = _context.Categorys.FirstOrDefault(category => category.Id == id);

            if(category == null)
            {
                return NotFound();
            }

            _mapper.Map(categoryDto, category);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _context.Categorys.FirstOrDefault(category => category.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
