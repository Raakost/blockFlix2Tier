using System;
using System.Collections.Generic;
using BlockFlixDLL.Entities;
using ExchangeRate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestMovieEntity
    {
        [TestMethod]
        public void TestCurrencyConversion()
        {
            Movie m = new Movie()
            {
                ID = 0,
                Price = 100
            };
            double priceInUSD = m.GetPriceInDifferentCurrency(Iso4217.USD);
            double priceInEUR = m.GetPriceInDifferentCurrency(Iso4217.EUR);
            //Check that the 3 prices are not the same value.
            Assert.AreNotEqual(priceInUSD, priceInEUR);
            Assert.AreNotEqual(priceInUSD, m.Price);
            Assert.AreNotEqual(priceInEUR, m.Price);
            //Test if the prices can be converted again and still give aproximately the same value.
            Assert.IsTrue(Math.Abs((Provider.Google.Convert(Iso4217.DKK, Iso4217.EUR, 100)) - priceInEUR) < 0.1 );
            Assert.IsTrue(Math.Abs((Provider.Google.Convert(Iso4217.DKK, Iso4217.USD, 100)) - priceInUSD) < 0.1);
        }
    }
}
