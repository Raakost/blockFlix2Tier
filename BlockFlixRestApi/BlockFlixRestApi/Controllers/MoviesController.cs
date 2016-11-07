using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BlockFlixDLL;
using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;

namespace BlockFlixRestApi.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IRepository<Movie> _mr = new Facade().GetMovieRepository();


        [HttpGet]
        public List<Movie> GetMovies()
        {
            return _mr.GetAll();
        }

        [HttpGet]
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = _mr.Get(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mr.Update(movie);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _mr.Create(movie);
            return CreatedAtRoute("DefaultApi", new { id = movie.ID }, movie);
        }

        [HttpDelete]
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = _mr.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            _mr.Remove(movie);
            return Ok(movie);
        }
    }
}