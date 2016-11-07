using System;
using System.Collections.Generic;
using System.Linq;
using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL.Repository
{
    class GenreRepository : IRepository<Genre>
    {
        public Genre Create(Genre genre)
        {
            using (var ctx = new MovieShopContext())
            {
                ctx.Genres.Add(genre);
                ctx.SaveChanges();
                return genre;
            }
        }

        public Genre Get(int id)
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Genres.FirstOrDefault(x => x.ID == id);
            }
        }

        public Genre Get(string email)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetAll()
        {
            using (var ctx = new MovieShopContext())
            {
                return ctx.Genres.ToList();
            }
        }

        public bool Remove(Genre t)
        {
            using (var ctx = new MovieShopContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
        }

        public Genre Update(Genre t)
        {
            using (var ctx = new MovieShopContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return t;
            }
        }
    }
}
