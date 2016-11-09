using System;
using System.Collections.Generic;
using System.Linq;
using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL.Repository
{
    class MovieRepository : IRepository<Movie>
    {
        
        public List<Movie> GetAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Movies.Include("Genres").ToList();
            }
        }

        public Movie Get(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Movies.Include("Genres").FirstOrDefault(x => x.ID == id);
            }
        }

        public Movie Get(string email)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Movie t)
        {
            using (var ctx = new MovieShopContext())
            {
                ctx.Entry(ctx.Movies.FirstOrDefault(x => x.ID == t.ID)).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
                return ctx.Movies.FirstOrDefault(x => x.ID == t.ID) == null;
            }
        }

        public Movie Update(Movie t)
        {
            using (var ctx = new MovieShopContext())
            {
                var existingMovie = ctx.Movies.Include("Genres").FirstOrDefault(m => m.ID == t.ID);
                if (existingMovie != null)
                {
                    existingMovie.Genres.Clear();
                    existingMovie.ImageURL = t.ImageURL;
                    existingMovie.TrailerURL = t.TrailerURL;
                    existingMovie.Price = t.Price;
                    existingMovie.Title = t.Title;
                    existingMovie.Year = t.Year;

                    if (t.Genres != null)
                        foreach (var genre in t.Genres)
                        {
                            existingMovie.Genres.Add(ctx.Genres.FirstOrDefault(x => x.ID == genre.ID));
                        }
                }
                ctx.SaveChanges();
                return t;
            }
        }

        public Movie Create(Movie t)
        {
            using (var ctx = new MovieShopContext())
            {
                List<Genre> genres = new List<Genre>();
                if (t.Genres != null)
                    foreach (var i in t.Genres)
                    {
                        genres.Add(ctx.Genres.FirstOrDefault(x => x.ID == i.ID));
                    }
                t.Genres = genres;
                ctx.Movies.Add(t);
                ctx.SaveChanges();
                return t;
            }
        }
    }
}
