using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly_Auth.Models;
using Vidly_Auth.DTOs;

namespace Vidly_Auth.Controllers.ApiContollers
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //get api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if(!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customers = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

            if (customers == null)
                return NotFound();

            return Ok(customers);
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
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDto)
        {
            //Lambdas and generics ???
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                NotFound();

            Mapper.Map<CustomerDTO, Customer>(customerDto, customerInDb);

            _context.SaveChanges();
            return Ok(customerDto);
        }

        //Delete api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok(customerInDb);
        }
    }
}
