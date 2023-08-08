using API_testing1.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;  // Para List
using System.Threading.Tasks;     // Para Task
using System;                     // Para NotImplementedException

namespace API_testing1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase  // Cambié Controller por ControllerBase
    {
        [HttpGet]
        public async Task<List<CustomerDTO>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<CustomerDTO> GetCustomer(long id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]  // Cambiado a HttpDelete
        public async Task<bool> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<CustomerDTO> CreateCustomer(CreateCustomerDTO customer) // Cambiado el nombre del método
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }
    }
}
