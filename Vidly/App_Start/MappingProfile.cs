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
            //Mapping Domain to DTO
            Mapper.CreateMap<Customer, CustomerDTo>();
            Mapper.CreateMap<Movie, MovieDTo>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTo>();
            Mapper.CreateMap<Genre, GenreDTo>();

            //Mapping DTO to Domain
            Mapper.CreateMap<CustomerDTo, Customer>().ForMember(c => c.id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTo, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            //Mapper.CreateMap<GenreDTo, Genre>();
        }
    }
}