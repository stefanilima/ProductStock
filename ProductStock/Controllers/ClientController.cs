using System;
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
    public class ClientController : ControllerBase
    {
        private ProductStockContext _context;
        private IMapper _mapper;

        public ClientController(ProductStockContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetClient()
        {
            return Ok(_context.Clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            Client client = _context.Clients.FirstOrDefault(client => client.Id == id);

            if (client != null)
            {
                return Ok(client);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientDto clientDto)
        {
            Client client = _mapper.Map<Client>(clientDto);

            _context.Clients.Add(client);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetClientById), new { Id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientDto clientDto)
        {
            Client client = _context.Clients.FirstOrDefault(client => client.Id == id);

            if(client == null)
            {
                return NotFound();
            }

            _mapper.Map(clientDto, client);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            Client client = _context.Clients.FirstOrDefault(client => client.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            _context.Remove(client);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
