using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Giangbb.Dtos;
using Giangbb.Models;

namespace Giangbb.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            //Id is the key property for the Movie/Customer class, and a key property should not be changed.
            //That’s why we get exception when update model.To resolve this, you need to tell AutoMapper to ignore
            //Id during mapping of a MovieDto to Movie


        }
    }
}