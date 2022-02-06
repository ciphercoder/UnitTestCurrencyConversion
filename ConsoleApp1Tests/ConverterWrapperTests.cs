using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class ConverterWrapperTests
    {
        private readonly ConverterWrapper _converterWrapper;

        public ConverterWrapperTests()
        {
            _converterWrapper = new ConverterWrapper();
        }
       
        [TestMethod()]
        [DataRow(12,Currency.EUR )]
        public void convertTest(decimal amount, Currency currency, decimal resultAmount)
        {
            //var result = _converterWrapper.convert(12, Currency.EUR, 1.14M);
            var calculatedResult = $"12 EUR = {12 * 1.14M} USD";
            
            Assert.AreEqual(result, calculatedResult);
        }

    }
}