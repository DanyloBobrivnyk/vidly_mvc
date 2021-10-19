using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();

            Mapper.CreateMap<Movie, MovieDTO>()
            .ForMember(m => m.Id, opt => opt.Ignore());
            
            Mapper.CreateMap<MovieDTO, Movie>()
            .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}