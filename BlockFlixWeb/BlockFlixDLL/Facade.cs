using BlockFlixDLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.GatewayServices;

namespace BlockFlixDLL
{
    public class Facade
    {
        private IServiceGateway<Genre> _genreServiceGateway;
        private IServiceGateway<Movie> _movieServiceGateway;
        private IServiceGateway<Customer> _customerServiceGateway;
        private IServiceGateway<Order> _orderServiceGateway;

        public IServiceGateway<Genre> GetGenreManager()
        {
            return _genreServiceGateway ?? (_genreServiceGateway = new GenreServiceGateway());
        }

        public IServiceGateway<Movie> GetMovieManager()
        {
            return _movieServiceGateway ?? (_movieServiceGateway = new MovieServiceGateway());
        }

        public IServiceGateway<Customer> GetCustomerManager()
        {
            return _customerServiceGateway ?? (_customerServiceGateway = new CustomerServiceGateway());
        }

        public IServiceGateway<Order> GetOrderManager()
        {
            return _orderServiceGateway ?? (_orderServiceGateway = new OrderServiceGateway());
        }
    }
}
