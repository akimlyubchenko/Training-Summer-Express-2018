using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BubbleJaggedSort.Tests
{
    [TestFixture]
    public class BubbleJaggedSortTests
    {
        [TestCase(new int[] { 3, 7, 1, -3 }, new int[] { 26, 12, 2 }, new int[] { 1, 2, 3 }, new int[] { 6, 7, 8, 6, 5, 4, 3 })]
        public void BubbleJaggedSortSum(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] actual = new int[4][];
            actual[0] = array0;
            actual[1] = array1;
            actual[2] = array2;
            actual[3] = array3;

            int[][] expected = new int[4][];
            expected[0] = array2;
            expected[1] = array0;
            expected[2] = array3;
            expected[3] = array1;

            BubbleJaggedSort.BubbleSort(actual, new Conditions.Sum().Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 1, -3 }, new int[] { 26, 12, 2 }, new int[] { 1, 2, 3 }, new int[] { 6, 7, 8, 6, 5, 4, 3 })]
        public void BubbleJaggedSortSumWithoutForm(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] actual = new int[4][];
            actual[0] = array0;
            actual[1] = array1;
            actual[2] = array2;
            actual[3] = array3;

            int[][] expected = new int[4][];
            expected[0] = array2;
            expected[1] = array0;
            expected[2] = array3;
            expected[3] = array1;

            BubbleJaggedSort.BubbleSort(actual, new Conditions.Sum().Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 1, -3 }, new int[] { 26, 12, 2 }, new int[] { 1, 2, 3 }, new int[] { 6, 7, 8, 6, 5, 4, 3 })]
        public void BubbleJaggedSortMinEl(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] actual = new int[4][];
            actual[0] = array0;
            actual[1] = array1;
            actual[2] = array2;
            actual[3] = array3;

            int[][] expected = new int[4][];
            expected[0] = array0;
            expected[1] = array2;
            expected[2] = array1;
            expected[3] = array3;

            BubbleJaggedSort.BubbleSort(actual, new Conditions.Min().Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 1, -3 }, new int[] { 26, 12, 2 }, new int[] { 1, 2, 3 }, new int[] { 6, 7, 8, 6, 5, 4, 3 })]
        public void BubbleJaggedSortMinElInverse(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] actual = new int[4][];
            actual[0] = array0;
            actual[1] = array1;
            actual[2] = array2;
            actual[3] = array3;

            int[][] expected = new int[4][];
            expected[0] = array3;
            expected[1] = array1;
            expected[2] = array2;
            expected[3] = array0;

            BubbleJaggedSort.BubbleSort(actual, new Conditions.InverseMin().Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 1, -3 }, new int[] { 26, 12, 2 }, new int[] { 1, 2, 3 }, new int[] { 6, 7, 8, 6, 5, 4, 3 })]
        public void BubbleJaggedSortMaxEl(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] actual = new int[4][];
            actual[0] = array0;
            actual[1] = array1;
            actual[2] = array2;
            actual[3] = array3;

            int[][] expected = new int[4][];
            expected[0] = array2;
            expected[1] = array0;
            expected[2] = array3;
            expected[3] = array1;

            BubbleJaggedSort.BubbleSort(actual, new Conditions.Max().Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 1, -3 }, new int[] { 26, 12, 2 }, new int[] { 1, 2, 3 }, new int[] { 6, 7, 8, 6, 5, 4, 3 })]
        public void BubbleJaggedSortMaxElInverse(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] actual = new int[4][];
            actual[0] = array0;
            actual[1] = array1;
            actual[2] = array2;
            actual[3] = array3;

            int[][] expected = new int[4][];
            expected[0] = array1;
            expected[1] = array3;
            expected[2] = array0;
            expected[3] = array2;

            BubbleJaggedSort.BubbleSort(actual, new Conditions.InverseMax().Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 1, -3 }, new int[] { 26, 12, 2 }, new int[] { 1, 2, 3 }, new int[] { 6, 7, 8, 6, 5, 4, 3 })]
        public void BubbleJaggedSortSumInverse(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] actual = new int[4][];
            actual[0] = array0;
            actual[1] = array1;
            actual[2] = array2;
            actual[3] = array3;

            int[][] expected = new int[4][];
            expected[0] = array1;
            expected[1] = array3;
            expected[2] = array0;
            expected[3] = array2;

            BubbleJaggedSort.BubbleSort(actual, new Conditions.InverseSum().Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 7, 1, -3 }, null, new int[] { 1, 2, 3 }, new int[] { 6, 7, 8, 6, 5, 4, 3 })]
        public void BubbleJaggedSortSumInverseWidthNullArrays(int[] array0, int[] array1, int[] array2, int[] array3)
        {
            int[][] actual = new int[4][];
            actual[0] = array0;
            actual[1] = array1;
            actual[2] = array2;
            actual[3] = array3;

            int[][] expected = new int[4][];
            expected[0] = array3;
            expected[1] = array0;
            expected[2] = array2;
            expected[3] = array1;

            BubbleJaggedSort.BubbleSort(actual, new Conditions.InverseSum().Compare);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BubbleJaggedSortExceptionArray()
         => Assert.Throws<ArgumentNullException>(()
             => BubbleJaggedSort.BubbleSort(null, new Conditions.Sum().Compare));

        [Test]
        public void BubbleJaggedSortExceptionDelegate()
        => Assert.Throws<ArgumentNullException>(()
            => BubbleJaggedSort.BubbleSort(new int[][] { new int[] { 26, 12, 2 } }, null));
    }
}
