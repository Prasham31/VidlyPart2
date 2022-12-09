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
        //MoviesController class derivied from controller class
        //View is helper method created from base Controller class

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
        public ActionResult Edit(int id)
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