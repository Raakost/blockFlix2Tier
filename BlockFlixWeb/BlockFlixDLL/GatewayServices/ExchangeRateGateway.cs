using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.Entities;
using Newtonsoft.Json;

namespace BlockFlixDLL.GatewayServices
{
    public class ExchangeRateGateway
    {
        private static void SetUpClientConnection(HttpClient client)
        {
            client.BaseAddress = new Uri("http://api.fixer.io");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static CurrencyJSON GetAll()
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync("/latest?symbols=USD,DKK").Result;
                if (response.IsSuccessStatusCode)
                {
                    CurrencyJSON currency;
                    //string Json = response.Content.ReadAsStringAsync().Result;
                    currency = JsonConvert.DeserializeObject<CurrencyJSON>(response.Content.ReadAsStringAsync().Result);
                    return currency;
                }
                return null;
            }
        }
    }
}
