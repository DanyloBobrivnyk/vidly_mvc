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
        private MovieDBContext _context;

        public CustomersController()
        {
            _context = new MovieDBContext();
        }

        //get api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        //get api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        //post api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerMapped = Mapper.Map<CustomerDTO, Customer>(customerDto);

            _context.Customers.Add(customerMapped);
            _context.SaveChanges();

            customerDto.Id = customerMapped.Id;

            return Created(new Uri(Request.RequestUri + "/" + customerMapped.Id), customerDto);
        }

        //put /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            //Lambdas and generics ???
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDTO, Customer>(customerDto, customerInDb);

            //This maper does thesame thing
            //customerInDb.Name = customerDto.Name;
            //customerInDb.BirthdayDate = customerDto.BirthdayDate;
            //customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            _context.SaveChanges();
        }

        //DElete api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
