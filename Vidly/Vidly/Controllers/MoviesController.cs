using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer{ Name = "Customer1"},
                new Customer{ Name = "Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        
        //GET: Movies
        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek!"},
                new Movie {Id = 2, Name = "Vall-e"}
            };

            var viewModel = new MoviesViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, byte? month)
        {
            return Content(year + "/" + month);
        }
    }
}