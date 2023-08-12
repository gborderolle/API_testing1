using API_testing1.DTOs;
using API_testing1.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_testing1.Models
{
    public interface ICustomer
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class Customer : ICustomer
    {
        [Key]
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        internal async Task<CustomerDTO> ToDTOAsync()
        {
            return Utls.mapper.Map<CustomerDTO>(this);
        }

        internal CustomerDTO ToDTO()
        {
            return Utls.mapper.Map<CustomerDTO>(this);
        }
    }
}
