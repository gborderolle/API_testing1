using API_testing1.DTOs;
using API_testing1.Models;
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
        
        public async Task<Customer> Get(long id)
        {
            return await Customer.FirstAsync(x => x.Id == id);
        }
        public async Task<Customer> Add(CreateCustomerDTO entityDTO)
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
            return await Get(response.Entity.Id ?? throw new InvalidOperationException("No se pudo guardar"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}