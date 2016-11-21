using System;
using System.Collections.Generic;
using BlockFlixDLL.Entities;
using BlockFlixDLL.GatewayServices;
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
            CurrencyJSON currencyJson = ExchangeRateGateway.GetAll();
            double USDrate = currencyJson.Currencies.USCurrency;
            double EURrate = currencyJson.Currencies.DanishCurrency;
            double priceInUSD = m.Price*USDrate;
            double priceInEUR = m.Price*EURrate;
            //Check that the 3 prices are not the same value.
            Assert.AreNotEqual(priceInUSD, priceInEUR);
            Assert.AreNotEqual(priceInUSD, m.Price);
            Assert.AreNotEqual(priceInEUR, m.Price);
            //Test if the prices can be converted again and still give aproximately the same value.
            currencyJson = ExchangeRateGateway.GetAll();
            USDrate = currencyJson.Currencies.USCurrency;
            EURrate = currencyJson.Currencies.DanishCurrency;
            Assert.IsTrue(Math.Abs(m.Price * EURrate - priceInEUR) < 0.1 );
            Assert.IsTrue(Math.Abs(m.Price * USDrate - priceInUSD) < 0.1);
        }
    }
}
