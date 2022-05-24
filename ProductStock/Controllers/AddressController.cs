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
    public class AddressController : ControllerBase
    {
        private ProductStockContext _context;
        private IMapper _mapper;

        public AddressController(ProductStockContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAddress()
        {
            return Ok(_context.Address);
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address != null)
            {
                return Ok(address);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateAddress([FromBody] AddressDto addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);

            _context.Address.Add(address);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddressById), new { Id = address.Id }, address);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] AddressDto addressDto)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null)
            {
                return NotFound();
            }

            _mapper.Map(addressDto, address);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);

            if (address == null)
            {
                return NotFound();
            }

            _context.Remove(address);
            _context.SaveChanges();

            return NoContent();
        }
    }
}