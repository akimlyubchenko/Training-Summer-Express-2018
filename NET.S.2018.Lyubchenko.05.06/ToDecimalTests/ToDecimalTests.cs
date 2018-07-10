using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ToDecimal.Tests
{
    [TestFixture]
    public class ToDecimalTests
    {
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("1AeF101", 16, ExpectedResult = 28242177)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10", 5, ExpectedResult = 5)]
        [TestCase("1Aec101", 15, ExpectedResult = 19733851)]
        public int ToDecimalConverter_SomeNumber_SomeNumberIn10Notation(string numberString, int notation)
         => ToDecimal.ToDecimalConverter(numberString, notation);

        [Test]
        public void ToDecimalConverter_11111111111111111111111111111111_OverflowException()
          => Assert.Throws<OverflowException>(() => ToDecimal.ToDecimalConverter("11111111111111111111111111111111", 2));

        [Test]
        public void ToDecimalConverter_WithNull_ThrowArgumentNullException()
           => Assert.Throws<ArgumentNullException>(() => ToDecimal.ToDecimalConverter(null,5));

        [Test]
        public void ToDecimalConverter_NotationLessAsNumber_ThrowArgumentException()
          => Assert.Throws<ArgumentException>(() => ToDecimal.ToDecimalConverter("SA123", 2));

        [Test]
        public void ToDecimalConverter_NotationMoreAsNumber_ThrowArgumentException()
         => Assert.Throws<ArgumentException>(() => ToDecimal.ToDecimalConverter("764241", 20));
    }
}
