using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly_Auth.DTOs;
using Vidly_Auth.Models;

namespace Vidly_Auth.Controllers.ApiControllers
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // POST: api/rentals
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDTO rentalDto)
        {
            //Deffencive approach
            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == rentalDto.CustomerId);

            if (!rentalDto.MovieIds.Any())
                return BadRequest("No movie Ids provided for rental.");

            if (customer == null)
                return BadRequest("Invalid customer Id.");

            var movies = _context.Movies.Where(
                m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or more movie Ids are invalid.");

            foreach (var movie in movies)
            {
                if(movie.NumberOfAvailable == 0)
                    return BadRequest("Movie is not available.");
                

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    RentalDate = DateTime.Now
                };

                movie.NumberOfAvailable --;
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
             
            return Ok();
        }   
    }
}