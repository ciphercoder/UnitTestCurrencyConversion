using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class ConverterTests
    {
        
        [TestMethod()]
        [DataRow(12, Currency.EUR,13.79,0.87)]
        [DataRow(10, Currency.USD, 8.70,0.87)]
        [DataRow(50, Currency.USD, 43.50, 0.87)]
        public void GetConversionTest(double amount, Currency currency, double processedResult, double rateFee)
        {

            var convertor = new Converter((decimal)amount, currency, (decimal)rateFee);

            var result = convertor.GetConversion();
            
            Assert.AreEqual(result, (decimal)processedResult);
        }

    }
}

