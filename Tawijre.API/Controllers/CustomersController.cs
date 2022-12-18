using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Twaijri.Core.Interfaces;
using Twijre.API.Dtos.Customer;
using Twijre.API.Dtos.Invoice;
using Twijre.Core.Interfaces;
using Twijre.EF.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Twijre.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISpecialCustomersRepository _specialCustomersRepository;

        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper , ISpecialCustomersRepository specialCustomersRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _specialCustomersRepository = specialCustomersRepository;
        }
        [HttpGet("GetCustomersIncludeInvoice/{id}")]
        public async Task<IActionResult> GetCustomersIncludeInvoice(int id)
        {
            CustomerDto customerDto = new CustomerDto();
            var customer = await _specialCustomersRepository.GetCustomersIncludeInvoice(id);
            customerDto = _mapper.Map<CustomerDto>(customer);
            
            return Ok(customerDto);
        }
         
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            if (customers.Any())
            {
                return Ok(_mapper.Map<List<CustomerDto>>(customers));

            }
            return NoContent();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id == null) return BadRequest();
                var customer = await _unitOfWork.Customers.GetByIdAsync(id);
                if (customer == null) return NotFound();
                return Ok(_mapper.Map<CustomerDto>(customer));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] CustomerCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var customer = _mapper.Map<Customer>(createDto);
                var result = await _unitOfWork.Customers.AddAsync(customer);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerUpdateDto updateDto)
        {
            if (id == null) return BadRequest();
            if (id != updateDto.Id) return BadRequest();
            var customer = _mapper.Map<Customer>(updateDto);

            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Complete();
            return Ok(_mapper.Map<CustomerDto>(customer));
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return BadRequest();
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null) return BadRequest();
            _unitOfWork.Customers.Delete(customer);
            _unitOfWork.Complete();
            return Ok();
        }

    }
}
