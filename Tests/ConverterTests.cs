using System.Collections.Generic;
using JiraTimeConverter;
using NUnit.Framework;

namespace Tests
{
    public class ConverterTests
    {
        public ConverterTests(Converter converter)
        {
            this.converter = converter;
        }
        
        [TestCase("1d", "2h", ExpectedResult = 10d)]
        public double Test1(IEnumerable<string> jiraTimeItems)
        {
            return converter.ConvertToNormalHours(jiraTimeItems);
        }

        private readonly Converter converter;
    }
}