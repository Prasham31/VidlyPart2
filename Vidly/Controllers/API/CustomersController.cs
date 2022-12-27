using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDTo> GetCustomers()
        {
           return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTo>);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer =  _context.Customers.SingleOrDefault(c=>c.id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDTo>(customer));
        }

        //POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTo customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTo, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.id = customer.id;

            return Created(new Uri(Request.RequestUri + "/" + customer.id),customerDTO);
        }

        //PUT api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDTo customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerFromDb = _context.Customers.SingleOrDefault(c => c.id == id);
            if (customerFromDb == null)
                return NotFound();

            Mapper.Map(customerDTO,customerFromDb);

            //customerFromDb.name = customerDTO.name;
            //customerFromDb.BirthDate = customerDTO.BirthDate;
            //customerFromDb.IsSubscribedToNewsLetter = customerDTO.IsSubscribedToNewsLetter;
            //customerFromDb.MembershipTypeid = customerDTO.MembershipTypeid;

            return Ok(_context.SaveChanges());
        }

        //DELETE api/customers/1
        [HttpDelete]
        public IHttpActionResult DeateCustomer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerFromDb = _context.Customers.SingleOrDefault(c => c.id == id);
            if (customerFromDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerFromDb);
            return Ok(_context.SaveChanges());
        }
    }
}
