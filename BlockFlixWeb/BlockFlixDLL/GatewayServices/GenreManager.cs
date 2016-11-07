using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockFlixDLL.GatewayServices
{
    class GenreServiceGateway : IServiceGateway<Genre>
    {
        public Genre Create(Genre genre)
        {
            using (var db = new MovieShopContext())
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return genre;
            }
        }

        public Genre Get(int ID)
        {
            using (var db = new MovieShopContext())
            {
                return db.Genres.FirstOrDefault(x => x.ID == ID);
            }
        }

        public Genre Get(string email)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetAll()
        {
            using (var db = new MovieShopContext())
            {
                return db.Genres.ToList();
            }
        }

        public bool Remove(Genre t)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }

        public Genre Update(Genre t)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }
    }
}
