using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NearestNumberCalculator.NearestNumberCalculator;

namespace NearestNumberCalculatorTests
{
    [TestClass]
    public class NearestNumberCalculatorTests
    {
        [TestMethod]
        public void NearestNumberCalculator_123456_6()
        {
            // Arr
            int number = 1234126;
            int expected = 1234162;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_12_21()
        {
            // Arr
            int number = 12;
            int expected = 21;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_513_531()
        {
            // Arr
            int number = 513;
            int expected = 531;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_2017_2071()
        {
            // Arr
            int number = 2017;
            int expected = 2071;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_414_441()
        {
            // Arr
            int number = 414;
            int expected = 441;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_144_414()
        {
            int number = 144;
            int expected = 414;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_1234321_1241233()
        {
            // Arr
            int number = 1234321;
            int expected = 1241233;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_1234126_1234162()
        {
            // Arr
            int number = 1234126;
            int expected = 1234162;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_3456432_3462345()
        {
            // Arr
            int number = 3456432;
            int expected = 3462345;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_10_Negative1()
        {
            // Arr
            int number = 10;
            int expected = -1;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NearestNumberCalculator_987654321_Negative1()
        {
            // Arr
            int number = 987654321;
            int expected = -1;

            // Act
            int actual = FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NearestNumberCalculator_NegativeNumber_Exception()
            => FindNextBiggerNumber(-1);
    }
}
