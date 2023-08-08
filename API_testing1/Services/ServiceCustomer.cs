using API_testing1.Context;
using API_testing1.DTOs;
using API_testing1.Models;

namespace API_testing1.Services
{
    public class ServiceCustomer
    {
        private readonly ContextDB _contextDB;

        public ServiceCustomer(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        internal async Task<CustomerDTO> CreateCustomer(CreateCustomerDTO customer)
        {
            Customer _customer = await _contextDB.Add(customer);
            return Utls.mapper.Map<CustomerDTO>(_customer);
        }
    }
}
