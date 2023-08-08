using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using API_testing1.DTOs;
using API_testing1.Models;
using AutoMapper;

namespace API_testing1.Services
{
    public class Utls
        {

            private static MapperConfiguration config = new(cfg =>
            {
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Customer, CustomerDTO>();

                cfg.CreateMap<CreateCustomerDTO, Customer>();
                cfg.CreateMap<Customer, CreateCustomerDTO>();
            });

            public static Mapper mapper { get; set; } = new(config);

        }

    }