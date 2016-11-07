using BlockFlixDLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.Repository;

namespace BlockFlixDLL
{
    public class Facade
    {
        private IRepository<Genre> _genreRepository;
        private IRepository<Movie> _movieRepository;
        private IRepository<Customer> _customerRepository;
        private IRepository<Order> _orderRepository;

        public IRepository<Genre> GetGenreRepository()
        {
            return _genreRepository ?? (_genreRepository = new GenreRepository());
        }

        public IRepository<Movie> GetMovieRepository()
        {
            return _movieRepository ?? (_movieRepository = new MovieRepository());
        }

        public IRepository<Customer> GetCustomerRepository()
        {
            return _customerRepository ?? (_customerRepository = new CustomerRepository());
        }

        public IRepository<Order> GetOrderRepository()
        {
            return _orderRepository ?? (_orderRepository = new OrderRepository());
        }
    }
}
