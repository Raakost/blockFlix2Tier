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
    public class GenresController : ApiController
    {        
        private readonly IRepository<Genre> _gr = new Facade().GetGenreRepository();

        [HttpGet]
        public IList<Genre> GetGenres()
        {
            return _gr.GetAll();
        }

        [HttpGet]
        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenre(int id)
        {
            Genre genre = _gr.Get(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _gr.Update(genre);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(Genre))]
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _gr.Create(genre);
            return CreatedAtRoute("DefaultApi", new { id = genre.ID }, genre);
        }

        [HttpDelete]
        [ResponseType(typeof(Genre))]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = _gr.Get(id);
            if (genre == null)
            {
                return NotFound();
            }
            _gr.Remove(genre);
            return Ok(genre);
        }
    }
}