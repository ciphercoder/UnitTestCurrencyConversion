using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new ConverterWrapper();

            test1.convert(20, Currency.USD, 0.87m);            
        }
    }

    public class ConverterWrapper
    {
        public void convert(decimal amountForConversion, Currency currency, decimal fee)
        {            
            var converter = new Converter(amountForConversion, currency, fee);
            var result = converter.GetConversion();

            var outputCurrency = currency == Currency.USD ? Currency.EUR : Currency.USD;

            var inputs = $"Demo inputs taken are: CurrencyToConvert:{currency}, Amount to Convert: {amountForConversion}, \nRate has been set in the 'CourseProvider' class as 1EUR = 0.87USD,\nUnit tests have been implemented\n\nThe output:";

            Console.WriteLine(inputs);

            Console.WriteLine($"{amountForConversion} {currency.ToString()} = {result} {outputCurrency}");
        }
    }

    public  class Converter
    {
        private decimal amountForConversion;
        private Currency currency;
        private decimal fee;

        //Conversion rate as per 1 USD 
        private decimal conversionRateEUR = 1.14M;
        private decimal conversionRateUSD = 0.87M;
        
        public Converter(decimal amountForConversion, Currency currency, decimal fee)
        {
            this.amountForConversion = amountForConversion;
            this.currency = currency;
            this.fee = fee;
        }

        public decimal GetConversion()
        {
            fee = CourseProvider.RateFee(currency);
            var convertedAmount = currency == Currency.EUR ? amountForConversion / fee : amountForConversion * fee;
            return Math.Round(convertedAmount, 2);
        }
    }

    public enum Currency
    {
        USD,
        EUR
    }

    public static class CourseProvider
    {        
        private static decimal USD_EUR = 0.87M;
        public static decimal RateFee(Currency currency)
        {
            return USD_EUR;
        }
    }
}
