using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRate;

namespace BlockFlixDLL.Entities
{
    public class Movie : AbstractEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public string TrailerURL { get; set; }
        public virtual List<Genre> Genres { get; set; }

        /// <summary>
        /// This method uses the nuget package "exchange-rate" to convert the movies price into another currency than the base currency
        /// of DKK, the exchange rate provider is Google, the calculated new currency is returned as a 'double' value.
        /// </summary>
        /// <param name="newCurrency"></param>
        /// <returns></returns>
        public double GetPriceInDifferentCurrency(Iso4217 newCurrency)
        {
            return Provider.Google.Convert(Iso4217.DKK, newCurrency, Price);
        }
    }
}
