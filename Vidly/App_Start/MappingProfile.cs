using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //Customer
            Mapper.CreateMap<Customer, CustomerDTo>().ForMember(c=>c.id, opt=> opt.Ignore());
            Mapper.CreateMap<CustomerDTo, Customer>();

            //Movie
            Mapper.CreateMap<Movie, MovieDTo>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTo, Movie>();
        }
    }
}