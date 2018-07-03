using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RootCalculaor.Tests
{
    [TestClass]
    public class RootCalculatetests
    {
        [TestMethod]
        public void FindNthRoot_1_5_00001_1()
        {
            double number = 1;
            int degree = 5;
            double precision = 0.0001;
            double expected = 1;

            double actual = RootCalculator.RootCalculator.FindNthRoot(number, degree, precision);

            Assert.AreEqual(expected, actual, precision);
        }

        [TestMethod]
        public void FindNthRoot_8_3_00001_2()
        {
            double number = 8;
            int degree = 3;
            double precision = 0.0001;
            double expected = 2;

            double actual = RootCalculator.RootCalculator.FindNthRoot(number, degree, precision);

            Assert.AreEqual(expected, actual, precision);
        }

        [TestMethod]
        public void FindNthRoot_0001_3_00001_2()
        {
            double number = 0.001;
            int degree = 3;
            double precision = 0.0001;
            double expected = 0.1;

            double actual = RootCalculator.RootCalculator.FindNthRoot(number, degree, precision);

            Assert.AreEqual(expected, actual, precision);
        }

        [TestMethod]
        public void FindNthRoot_004100625_4_00001_045()
        {
            double number = 0.04100625;
            int degree = 4;
            double precision = 0.0001;
            double expected = 0.45;

            double actual = RootCalculator.RootCalculator.FindNthRoot(number, degree, precision);

            Assert.AreEqual(expected, actual, precision);
        }

        [TestMethod]
        public void FindNthRoot_27_3_00001_3()
        {
            double number = 27;
            int degree = 3;
            double precision = 0.0001;
            double expected = 3;

            double actual = RootCalculator.RootCalculator.FindNthRoot(number, degree, precision);

            Assert.AreEqual(expected, actual, precision);
        }

        [TestMethod]
        public void FindNthRoot_Negative0008_3_01_Negative02()
        {
            double number = -0.008;
            int degree = 3;
            double precision = 0.01;
            double expected = -0.2;

            double actual = RootCalculator.RootCalculator.FindNthRoot(number, degree, precision);

            Assert.AreEqual(expected, actual, precision);
        }

        [TestMethod]
        public void FindNthRoot_0004241979_9_000000001_0545()
        {
            double number = 0.004241979;
            int degree = 9;
            double precision = 0.00000001;
            double expected = 0.545;

            double actual = RootCalculator.RootCalculator.FindNthRoot(number, degree, precision);

            Assert.AreEqual(expected, actual, precision);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_NegativeNumberEvenDegree_Exception()
            => RootCalculator.RootCalculator.FindNthRoot(-1, 6);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterNthRoot_NegativeDegree_Exception()
            => RootCalculator.RootCalculator.FindNthRoot(2, -4);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterNthRoot_NegativePrecision_Exception()
            => RootCalculator.RootCalculator.FindNthRoot(2,2,-2);
    }
}
