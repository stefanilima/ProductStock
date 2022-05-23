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
    public class PaymentTypeController : ControllerBase
    {
        private ProductStockContext _context;
        private IMapper _mapper;

        public PaymentTypeController(ProductStockContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPaymentType()
        {
            return Ok(_context.PaymentType);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentTypeById(int id)
        {
            PaymentType paymentType = _context.PaymentType.FirstOrDefault(order => order.Id == id);

            if (paymentType != null)
            {
                return Ok(paymentType);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreatePaymentType([FromBody] PaymentTypeDto paymentTypeDto)
        {
            PaymentType paymentType = _mapper.Map<PaymentType>(paymentTypeDto);

            _context.PaymentType.Add(paymentType);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPaymentTypeById), new { Id = paymentType.Id }, paymentType);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePaymentType(int id, [FromBody] PaymentTypeDto paymentTypeDto)
        {
            PaymentType paymentType = _context.PaymentType.FirstOrDefault(paymentType => paymentType.Id == id);

            if (paymentType == null)
            {
                return NotFound();
            }

            _mapper.Map(paymentTypeDto, paymentType);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePaymentType(int id)
        {
            PaymentType paymentType = _context.PaymentType.FirstOrDefault(paymentType => paymentType.Id == id);

            if (paymentType == null)
            {
                return NotFound();
            }

            _context.Remove(paymentType);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
