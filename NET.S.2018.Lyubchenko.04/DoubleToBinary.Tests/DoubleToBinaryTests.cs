using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Converter.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void DoubleToBinaryString_255Point255_Binary()
        {
            string expected = "0100000001101111111010000010100011110101110000101000111101011100";
            double number = 255.255;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleToBinaryString_Negative255Point255_Binary()
        {
            string expected = "1100000001101111111010000010100011110101110000101000111101011100";
            double number = -255.255;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleToBinaryString_4294967295Point0_Binary()
        {
            string expected = "0100000111101111111111111111111111111111111000000000000000000000";
            double number = 4294967295.0;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleToBinaryString_doubleMinValue_Binary()
        {
            string expected = "1111111111101111111111111111111111111111111111111111111111111111";
            double number = double.MinValue;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleToBinaryString_doubleMaxValue_Binary()
        {
            string expected = "0111111111101111111111111111111111111111111111111111111111111111";
            double number = double.MaxValue;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleToBinaryString_doubleEpsilon_Binary()
        {
            string expected = "0000000000000000000000000000000000000000000000000000000000000001";
            double number = double.Epsilon;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DoubleToBinaryString_doubleNaN_Binary()
        {
            string expected = "1111111111111000000000000000000000000000000000000000000000000000";
            double number = double.NaN;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DoubleToBinaryString_doubleNegativeInfinity_Binary()
        {
            string expected = "1111111111110000000000000000000000000000000000000000000000000000";
            double number = double.NegativeInfinity;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleToBinaryString_doublePositiveInfinity_Binary()
        {
            string expected = "0111111111110000000000000000000000000000000000000000000000000000";
            double number = double.PositiveInfinity;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleToBinaryString_Negative0_Binary()
        {
            string expected = "1000000000000000000000000000000000000000000000000000000000000000";
            double number = -0.0;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleToBinaryString_0_Binary()
        {
            string expected = "0000000000000000000000000000000000000000000000000000000000000000";
            double number = 0.0;

            string actual = DoubleToBinary.DoubleToBinaryString(number);

            Assert.AreEqual(expected, actual);
        }
    }
}
