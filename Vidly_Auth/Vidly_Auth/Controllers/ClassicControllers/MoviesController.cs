using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly_Auth.Models;
using Vidly_Auth.ViewModels;
using Vidly_Auth.Models;

namespace Vidly_Auth.Controllers.ClassicControllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var genreTypes = _context.Genres.ToList();

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genreTypes
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = UserRoles.CanManageMovies)]
        public ViewResult New()
        {
            var genreTypes = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {   
                Genres = genreTypes
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            //If some of the properties are not valid => reload the page and show validation errors.
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            //Add new movie if there is default int value provided by the view.
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberOfAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);
            }
            else
            {
                //Edit it.
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Title = movie.Title;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.NumberOfAvailable = movieInDb.NumberOfAvailable;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        
        //GET: Movies
        [Route ("Movies")]
        public ViewResult Index()
        {
            if (User.IsInRole(UserRoles.CanManageMovies))
                return View("List");
            else
                return View("ReadOnlyList");

        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, byte? month)
        {
            return Content(year + "/" + month);
        }
    }
}