using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL.GatewayServices
{
    class OrderServiceGateway : IServiceGateway<Order>
    {
        public List<Order> GetAll()
        {
            using (var db = new MovieShopContext())
            {
                return db.Orders.Include("Customers").Include("Movies").ToList();
            }
        }

        public Order Get(int ID)
        {
            using (var db = new MovieShopContext())
            {
                return db.Orders.FirstOrDefault(x => x.ID == ID);
            }
        }

        public Order Get(string email)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Order t)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(db.Orders.FirstOrDefault(x => x.ID == t.ID)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Orders.FirstOrDefault(x => x.ID == t.ID) == null;
            }
        }

        public Order Update(Order t)
        {
            throw new NotImplementedException();
        }

        public Order Create(Order t)
        {
            using (var db = new MovieShopContext())
            {
                List<Movie> movies = new List<Movie>();
                foreach (var i in t.Movies)
                {
                    movies.Add(db.Movies.FirstOrDefault(x => x.ID == i.ID));
                }
                t.Movies = movies;
                db.Orders.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}
