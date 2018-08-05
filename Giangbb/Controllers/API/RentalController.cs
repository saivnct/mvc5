using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Giangbb.Dtos;
using Giangbb.Models;
using Giangbb.Utils;

namespace Giangbb.Controllers.API
{
    public class RentalController : ApiController
    {

        private ApplicationDbContext _mDbContext;

        public RentalController()
        {
            this._mDbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._mDbContext.Dispose();           
        }
        

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

//            Customer customer = _mDbContext.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
//
//            if (customer == null)
//            {
//                return BadRequest("Invalid customer id");
//            }
//
//            foreach (var movieId in rentalDto.MovieIds)
//            {
//                Movie movie = _mDbContext.Movies.SingleOrDefault(c => c.Id == movieId);
//                if (movie == null)
//                {
//                    return BadRequest();
//                }
//
//                Rental rental = new Rental {Customer = customer, Movie = movie, DateRented = DateUtils.Now()};
//                _mDbContext.Rentals.Add(rental);
//            }
//            _mDbContext.SaveChanges();


            var customer = _mDbContext.Customers.Single(c => c.Id == rentalDto.CustomerId); //if wrong id -> throw exception


            //select * from movies where id in (1,2,3)
            var movies = _mDbContext.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable <= 0) {
                    return BadRequest(String.Format("Movie {0} is not available", movie.Name));
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateUtils.Now()
                };
                
                _mDbContext.Rentals.Add(rental);
                
               
            }

            _mDbContext.SaveChanges();

            return Ok();
        }
    }
}
