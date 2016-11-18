using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlockFlixDLL.Entities
{
    public class Currency
    {
        [JsonProperty("DKK")]
        public double DanishCurrency { get; set; }
        [JsonProperty("USD")]
        public double USCurrency { get; set; }
    }
}
