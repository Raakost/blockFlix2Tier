using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL.GatewayServices
{
    class MovieServiceGateway : IServiceGateway<Movie>
    {

        private readonly IServiceGateway<Genre> _gm = new Facade().GetGenreManager();

        public List<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie Get(int ID)
        {
            throw new NotImplementedException();
        }

        public Movie Get(string email)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Movie t)
        {
            throw new NotImplementedException();
        }

        public Movie Update(Movie t)
        {
            throw new NotImplementedException();
        }

        public Movie Create(Movie t)
        {
            throw new NotImplementedException();
        }
    }
}
