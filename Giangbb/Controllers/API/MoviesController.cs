using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Giangbb.Dtos;
using Giangbb.Models;

namespace Giangbb.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _mContext;

        public MoviesController()
        {
            _mContext = new ApplicationDbContext();            
        }

        protected override void Dispose(bool disposing)
        {
            this._mContext.Dispose();
        }

        //GET /api/movies/
        public IHttpActionResult GetMovies(string query)
        {
            var movies = _mContext.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0 );
            if (!String.IsNullOrWhiteSpace(query))
            {
                movies = movies.Where(m => m.Name.Contains(query));
            }

            var movieDtos = movies.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        //POST /api/movies/
        [HttpPost]
        public IHttpActionResult CreateMovies(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.NumberAvailable = movie.NumberInStock;
            _mContext.Movies.Add(movie);
            _mContext.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/movies/id
        [HttpPut]
        public IHttpActionResult UpdateMovies(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = _mContext.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map<MovieDto, Movie>(movieDto, movie);
            _mContext.SaveChanges();

            return Ok();
        }

        //DELETE /api/movies/id
        [HttpDelete]
        public IHttpActionResult DeleteMovies(int id)
        {
            var movie = _mContext.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _mContext.Movies.Remove(movie);
            _mContext.SaveChanges();

            return Ok();
        }

    }
}
