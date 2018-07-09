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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>());
        }
    }
}