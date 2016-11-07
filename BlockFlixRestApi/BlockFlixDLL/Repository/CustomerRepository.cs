using System.Collections.Generic;
using System.Linq;
using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL.Repository
{
    class CustomerRepository : IRepository<Customer>
    {
        public List<Customer> GetAll()
        {
            using (var db = new MovieShopContext())
            {
                return db.Customers.Include("Orders").ToList();
            }
        }

        public Customer Get(int id)
        {
            using (var db = new MovieShopContext())
            {
                var customer = db.Customers.Include("Address").FirstOrDefault(x => x.ID == id);
                return customer;
            }
        }
        public Customer Get(string email)
        {
            using (var db = new MovieShopContext())
            {
                return db.Customers.Include("Address").FirstOrDefault(x => x.Email == email);
            }
        }

        public bool Remove(Customer t)
        {
            using (var db = new MovieShopContext())
            {
                db.Entry(db.Customers.FirstOrDefault(x => x.ID == t.ID)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return db.Customers.FirstOrDefault(x => x.ID == t.ID) == null;
            }
        }

        public Customer Update(Customer t)
        {
            using (var db = new MovieShopContext())
            {
                var existingCustomer = db.Customers.Include("Orders").FirstOrDefault(x => x.ID == t.ID);
                if (existingCustomer != null)
                {
                    existingCustomer.FirstName = t.FirstName;
                    existingCustomer.LastName = t.LastName;
                    existingCustomer.Address = t.Address;
                    existingCustomer.Email = t.Email;
                    existingCustomer.Phone = t.Phone;
                }
                db.SaveChanges();
                return t;
            }
        }

        public Customer Create(Customer t)
        {
            using (var db = new MovieShopContext())
            {
                db.Customers.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}
