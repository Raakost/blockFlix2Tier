using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL.GatewayServices
{
    public class MovieServiceGateway : IServiceGateway<Movie>
    {
        private void SetUpClientConnection(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:52164/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Movie Create(Movie t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.PostAsJsonAsync("api/wishes", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Movie>().Result;
                }
                return null;
            }
        }

        public Movie Get(string email)
        {
            throw new NotImplementedException();
        }

        public Movie Get(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52164/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("/api/movies").Result;

                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsAsync<List<Movie>>().Result;

                //    if (response.IsSuccessStatusCode)
                //    {
                //        return response.Content.ReadAsAsync<List<Movie>>().Result;
                //    }
                //}
                //return new List<Movie>();
            }
        }

        public bool Remove(Movie t)
        {
            throw new NotImplementedException();
        }

        public Movie Update(Movie t)
        {
            throw new NotImplementedException();
        }
    }
}
