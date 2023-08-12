using API_testing1.DTOs;
using API_testing1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API_testing1.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        
        public async Task<Customer> CreateCustomer(CreateCustomerDTO entityDTO)
        {
            Customer entity = new()
            {
                Id = null,
                Name = entityDTO.Name,
                Email = entityDTO.Email,
                Phone = entityDTO.Phone,
                Address = entityDTO.Address,
            };
            EntityEntry<Customer> response = await Customer.AddAsync(entity);
            await SaveChangesAsync();
            return await GetCustomer(response.Entity.Id ?? throw new InvalidOperationException("No se pudo guardar"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        internal async Task<Customer> GetCustomer(long id)
        {
            return await Customer.FirstAsync(x => x.Id == id);
        }

        internal async Task<bool> DeleteCustomer(long id)
        {
            Customer entity = await GetCustomer(id);
            Customer.Remove(entity);
            SaveChanges();
            return true;
        }

        internal async Task<List<CustomerDTO>> GetCustomers()
        {
            return await Customer.Select(c => c.ToDTO()).ToListAsync();
        }

    }
}