using AutoMapper;
using M5NETCORE_EFSALES.CORE.DTOs;
using M5NETCORE_EFSALES.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.INFRASTRUCTURE.Mappings
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Customer, CustomerDTO>();
            //.ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Country));
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Customer, CustomerCountryDTO>();
            CreateMap<CustomerCountryDTO, Customer>();
            CreateMap<Customer, CustomerPostDTO>();
            CreateMap<CustomerPostDTO, Customer>();
        }



    }
}
