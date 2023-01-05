using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/movies
        public IEnumerable<MovieDTo> GetMovies()
        {
            return _context.Movies.
                Include(m => m.Genres).ToList().Select(Mapper.Map<Movie,MovieDTo>);
        }

        //GET api/movies/1
        public IHttpActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie,MovieDTo>(movie));
        }

        //POST api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTo movieDTo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTo, Movie>(movieDTo);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTo.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTo);
        }

        //PUT api/movie/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTo movieDTo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieFromDb = _context.Movies.SingleOrDefault(m=>m.Id == id);
            if (movieFromDb == null)
                return NotFound();

            Mapper.Map(movieDTo, movieFromDb);

            return Ok(_context.SaveChanges());
        }


        //DELETE api/movie/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieFromDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieFromDb == null)
                return NotFound();

            _context.Movies.Remove(movieFromDb);
            return Ok(_context.SaveChanges());
        }
    }
}
