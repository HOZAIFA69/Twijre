using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Twijre.API.Dtos.Customer;
using Twijre.API.Dtos.Invoice;
using Twijre.Core.Interfaces;
using Twijre.EF.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Twijre.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Invoices = await _unitOfWork.Invoices.GetAllAsync();
            if (Invoices.Any())
            {
                return Ok(_mapper.Map<List<InvoicesDto>>(Invoices));

            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id == null) return BadRequest();
                var Invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
                if (Invoice == null) return NotFound();
                return Ok(_mapper.Map<InvoicesDto>(Invoice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var invoice = _mapper.Map<Invoice>(createDto);
                invoice.Value = createDto.InvoiceValue;
                var result = await _unitOfWork.Invoices.AddAsync(invoice);
                _unitOfWork.Complete();
                return Ok(_mapper.Map<InvoicesDto>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InvoiceUpdateDto updateDto)
        {
            if (id == null) return BadRequest();
            if (id != updateDto.Id) return BadRequest();
            var invoice = _mapper.Map<Invoice>(updateDto);

            _unitOfWork.Invoices.Update(invoice);
            _unitOfWork.Complete();
            return Ok(_mapper.Map<InvoicesDto>(invoice));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return BadRequest();
            var Invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            if (Invoice == null) return BadRequest();
            _unitOfWork.Invoices.Delete(Invoice);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
