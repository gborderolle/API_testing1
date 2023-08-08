using API_testing1.DTOs;
using Microsoft.AspNetCore.Mvc;
using API_testing1.Services;

namespace API_testing1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase  // Cambié Controller por ControllerBase
    {
        private readonly ServiceCustomer _serviceCustomer;

        public CustomerController(ServiceCustomer serviceCustomer)
        {
            _serviceCustomer = serviceCustomer;
        }

        [HttpGet]
        public async Task<List<CustomerDTO>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer(long id)
        {
            var vacio = new CustomerDTO();
            return new OkObjectResult(vacio);
        }

        [HttpDelete("{id}")]  // Cambiado a HttpDelete
        public async Task<bool> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDTO))]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDTO customer) // Cambiado el nombre del método
        {
            CustomerDTO result = await _serviceCustomer.CreateCustomer(customer);
            return new CreatedResult($"http://localhost:5001/api/customer/{result.Id}", null);
        }

        [HttpPut]
        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }
    }
}