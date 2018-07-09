﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Giangbb.Models;
using Giangbb.ViewModels;

namespace Giangbb.Controllers
{   

    public class MoviesController : AbstractController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            this._context = new ApplicationDbContext();            
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            //pass data to view
            //way 1:
            //inview <h2>@Model.Name</h2> 
            //            return View(movie);

            //way2: using dictionary
            //in view <h2>@((Movie) ViewData["Movie"].Name)</h2> 
            //            ViewData["Movie"] = movie;
            //            return View();

            //way3: using ViewBag
            //in view <h2>@((Movie) ViewBag.Movie.Name)</h2> 
            //            ViewBag.Movie = movie;
            //            return View();


            //pass many obj to view
            var customers = new List<Customer>()
            {
                new Customer {Name = "a"},
                new Customer {Name = "b"},
                new Customer {Name = "c"}
            };

            var ramdomMoviewViewModel = new RandomMovieViewModel { Customers = customers, Movie = movie };
            return View(ramdomMoviewViewModel);




            //            return View(movie);
            //            return Content("Hello world");
            //            return HttpNotFound();
            //            return new EmptyResult();
            //            return RedirectToAction("Index", "Home");
            //            return RedirectToAction("Index", "Home",new {page = 1, sortBy = "name"});


            //ActionResult subtype:
            //ViewResult -> View()
            //PartialViewResult -> PartialView()
            //ContentResult -> Content() //simple text
            //RedirectResult -> Redirect() //redirect user to a url
            //RedirectToRouteResult -> RedirectToAction()   //redirect user to an action
            //JsonResult -> Json()
            //FileResult -> File()
            //HttpNotFoundResult -> HttpNotFound()  //404 Error
            //EmptyResult -> action dont need to return any value

        }




        public ActionResult Index()
        {
            List<Movie> movies = _context.Movies.Include(c => c.Genre).ToList();
            ViewBag.Movies = movies;

            return View();
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                id = 1;
            }


            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }            

            return View(movie);
        }

        //        public ActionResult Index(int? pageIndex, string sortBy)
        //        {
        //            if (!pageIndex.HasValue)
        //            {
        //                pageIndex = 1;
        //            }
        //
        //            if (string.IsNullOrWhiteSpace(sortBy))
        //            {
        //                sortBy = "Name";
        //            }
        //
        //            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //        }

        //Constraints: range,min,max,minlength,maxlength,int,float,guid
        [Route("movies/released/{year:int:range(1900,2018)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}