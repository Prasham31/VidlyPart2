using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //MoviesController class derivied from controller class
        //View is helper method created from base Controller class

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("Movies/Index")]
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genres).ToList();
            return View(movies);
        }

        [Route("Movies/Index/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genres).SingleOrDefault(u=>u.Id == id);
            if (movie == null)
                return HttpNotFound();        
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var movieViewModel = new MovieFormViewModel(movie)
            {                              
                Genre = _context.Genres.ToList()
            };

            return View("New", movieViewModel);
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            MovieFormViewModel movieViewModel = new MovieFormViewModel
            {
                Genre = genre
            };
            return View(movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genre = _context.Genres.ToList();
                MovieFormViewModel movieViewModel = new MovieFormViewModel(movie)
                {
                    Genre = genre
                };
                return View("New",movieViewModel);
            }
            //Add movie to DB
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }               
            else
            {
                //Update movie
                var movieInDb = _context.Movies.Single(m=>m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = DateTime.Now;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name="Shrek!"};

            var customers = new List<Customer> 
            {
                new Customer { name= "Tejal"} ,
                new Customer { name= "Meetal"}
            };

            var viewModel = new RandomMovieViewModel() { 
                Movie = movie ,
                Customers = customers
            };

            //ViewData["Movie"] = movie;
            //ViewBag.MovieVB = movie;


            return View(viewModel); //using view models
            //return View(movie); pass Movie model so that view can render by passing model to view

            #region showing more action results

            //return Content("Hello World!"); //Content helper method

            //return HttpNotFound();

            //return new EmptyResult(); //for EmptyResult we dont have any helper method so return like this

            //return RedirectToAction("Index","Home", new {page = 1 , sortby = "name"}); 

            #endregion
        }

        #region MVC fundamentals
        //Movies/Edit/1
        public ActionResult EditOld(int id)
        {
            return Content("id = " + id); //e.g., how request data is mapped to parameter of action
        }

        //Movies
        public ActionResult Index(int? pageIndex,string sortBy)
        {
            if(!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageIndex{0}&sortBy{1}",pageIndex,sortBy));
        }

        public ActionResult ByRelaeaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


        [Route("movies/releasedyear/{year}")]
        public ActionResult ByRelaeaseYear(string year)
        {
            return Content(year);
        }

        #endregion
    }
}