using API_testing1.DTOs;
using Microsoft.AspNetCore.Mvc;
using API_testing1.Services;

namespace API_testing1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase 
    {
        private readonly ServiceCustomer _serviceCustomer;

        public CustomerController(ServiceCustomer serviceCustomer)
        {
            _serviceCustomer = serviceCustomer;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDTO>))]
        public async Task<ActionResult> GetCustomers()
        {
            var result = await _serviceCustomer.GetCustomers();
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer(long id)
        {
            CustomerDTO result = await _serviceCustomer.GetCustomer(id);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDTO))]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var result = await _serviceCustomer.DeleteCustomer(id);
            return new OkObjectResult(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDTO))]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDTO customer)
        {
            CustomerDTO result = await _serviceCustomer.CreateCustomer(customer);
            return new CreatedResult($"http://localhost:5001/api/customer/{result.Id}", null);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDTO))]
        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }
    }
}