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
            return await _contextDB.CreateCustomer(customer).Result.ToDTOAsync();
            //return Utls.mapper.Map<CustomerDTO>(_customer);
        }

        internal async Task<CustomerDTO> GetCustomer(long id)
        {
            return await _contextDB.GetCustomer(id).Result.ToDTOAsync();
        }

         internal async Task<bool> DeleteCustomer(long id)
        {           
            return await _contextDB.DeleteCustomer(id);
        }

        internal async Task<List<CustomerDTO>> GetCustomers()
        {
            return await _contextDB.GetCustomers();
        }
    }
}
