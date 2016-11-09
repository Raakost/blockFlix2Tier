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
    public class GenreServiceGateway : IServiceGateway<Genre>
    {
        private void SetUpClientConnection(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:52164/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Genre Create(Genre t)
        {
            throw new NotImplementedException();
        }

        public Genre Get(string email)
        {
            throw new NotImplementedException();
        }

        public Genre Get(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52164/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/wishes").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Genre>>().Result;
                }
            }
            return new List<Genre>();
        }

        public bool Remove(Genre t)
        {
            throw new NotImplementedException();
        }

        public Genre Update(Genre t)
        {
            throw new NotImplementedException();
        }
    }
}
