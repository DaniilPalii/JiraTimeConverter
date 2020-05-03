using System.Collections.Generic;
using JiraTimeConverter;
using NUnit.Framework;

namespace Tests
{
    public class ConverterTests
    {
        [SetUp]
        public void SetUp()
        {
            converter = new Converter();
        }
        
        [Test]
        public void Test()
        {
            Assert.That(converter.ConvertToNormalHours(new[] { "1d" }), Is.EqualTo(8));
            Assert.That(converter.ConvertToNormalHours(new[] { "1d", "2h" }), Is.EqualTo(10));
            Assert.That(converter.ConvertToNormalHours(new[] { "1d", "2h", "30m" }), Is.EqualTo(10.5));
        }

        private Converter converter;
    }
}