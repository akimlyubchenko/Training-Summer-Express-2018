using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearcher.Tests
{
    [TestClass]
    public class BinarySearcherTests
    {
        readonly Comparison<int> compar = (a, b) =>
        {
            if (a - b > 0)
            {
                return 1;
            }

            if (a - b < 0)
            {
                return -1;
            }

            return 0;
        };

        [TestMethod]
        public void BinarySearcher_Array_6()
        {
            int[] array = new int[] { 1, 3, 6, 8 };
            int expected = 2;

            int actual = BinarySearcher<int>.RequiredNumber(array, 6, compar);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearcher_Array_8()
        {
            int[] array = new int[] { 1, 4, 8, 15 };
            int expected = 2;

            int actual = BinarySearcher<int>.RequiredNumber(array, 8, compar);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearcher_Array_15()
        {
            int[] array = new int[] { 1, 2, 4, 8, 13, 15 };
            int expected = 5;

            int actual = BinarySearcher<int>.RequiredNumber(array, 15, compar);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinarySearcher_Array_3Point7()
        {
            double[] array = new double[] { 1, 1.5, 2.7, 2.8, 3.5, 3.7, 15.32 };
            int expected = 5;

            int actual = BinarySearcher<double>.RequiredNumber(array, 3.7, (a, b) =>
            {
                if (a - b > 0)
                {
                    return 1;
                }

                if (a - b < 0)
                {
                    return -1;
                }

                return 0;
            });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearcher_Array_Exception1()
            => BinarySearcher<int>.RequiredNumber(null, 1, compar);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearcher_Array_Exception2()
           => BinarySearcher<int>.RequiredNumber(new int[] { }, 1, compar);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearcher_Array_Exception3()
           => BinarySearcher<int>.RequiredNumber(new int[] { 1, 2, 3 }, 1, null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearcher_Array_Exception4()
           => BinarySearcher<int>.RequiredNumber(new int[] { 1, 2, 3 }, 5, compar);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearcher_Array_Exception5()
           => BinarySearcher<int>.RequiredNumber(new int[] { 1, 2, 3 }, -2, compar);
    }
}
