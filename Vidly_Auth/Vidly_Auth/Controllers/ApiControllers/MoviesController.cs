using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_Auth.DTOs;
using Vidly_Auth.Models;

namespace Vidly_Auth.Controllers.ApiContollers
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //get api/movies
        public IHttpActionResult GetMovies()
        {

            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);

            if (movies == null)
                return NotFound();

            return Ok(movies);
        }

        //get api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        /// <summary>
        /// Post api/movies 
        /// </summary>
        /// <param name="movieDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            
            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            movieDto.DateAdded = movie.DateAdded;
                
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //put api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map<MovieDTO, Movie>(movieDto, movieInDb);

            _context.SaveChanges();
            return Ok(movieDto);
        }

        //delete api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok(movieInDb);
        }
    }
}
