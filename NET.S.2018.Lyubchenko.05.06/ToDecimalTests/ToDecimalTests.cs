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
        public int ToDecimalConverter_0110111101100001100001010111111_2_934331071(string numberString, int notation)
           => ToDecimal.ToDecimalConverter(numberString, notation);

        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        public int ToDecimalConverter_01101111011001100001010111111_2_233620159(string numberString, int notation)
          => ToDecimal.ToDecimalConverter(numberString, notation);

        [TestCase("1AeF101", 16, ExpectedResult = 28242177)]
        public int ToDecimalConverter_1AeF101_16_28242177(string numberString, int notation)
          => ToDecimal.ToDecimalConverter(numberString, notation);

        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        public int ToDecimalConverter_1ACB67_16_1756007(string numberString, int notation)
          => ToDecimal.ToDecimalConverter(numberString, notation);

        [TestCase("764241", 8, ExpectedResult = 256161)]
        public int ToDecimalConverter_764241_8_256161(string numberString, int notation)
         => ToDecimal.ToDecimalConverter(numberString, notation);

        [TestCase("10", 5, ExpectedResult = 5)]
        public int ToDecimalConverter_10_5_5(string numberString, int notation)
         => ToDecimal.ToDecimalConverter(numberString, notation);

        [TestCase("1Aec101", 15, ExpectedResult = 19733851)]
        public int ToDecimalConverter_1Aec101_15_19733851(string numberString, int notation)
         => ToDecimal.ToDecimalConverter(numberString, notation);

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
