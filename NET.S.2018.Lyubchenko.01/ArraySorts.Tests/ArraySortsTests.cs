// <copyright file = "ArraySortsTests.cs" company = "EPAM">
// Sort Tests
// </copyright>
namespace ArraySorts.Tests
{
    using System;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test sort array
    /// </summary>
    [TestClass]
    public class ArraySortsTests
    {
        #region QuickSortTests definition
        /// <summary>
        /// Very big array(stop working around 100M and 200M elements of array)
        /// </summary>
        [TestMethod]
        public void QuickSort_BigArray_SortedArray()
        {
            Random rand = new Random();

            // Arr
            int[] array = new int[100000001];
            int[] expected = new int[100000001];
            for (int i = 0; i < expected.Length - 1; i++)
            {
                expected[i] = rand.Next(1000000);
            }

            // Act
            ArraySorts.Quicksort(ref array, 0, array.Length - 1);

            // Assert
            if (!ArraySorts.IsSort(array))
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Checks if arrays are equal
        /// </summary>
        [TestMethod]
        public void Quicksort_unsortedarray163854_sortedarray134568()
        {
            // Arrange
            int[] intarr = new int[6] { 1, 6, 3, 8, 5, 4 };
            int[] expectedarr = new int[6] { 1, 3, 4, 5, 6, 8 };

            // Act
            ArraySorts.Quicksort(ref intarr, 0, intarr.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expectedarr, intarr);
        }

        /// <summary>
        /// Test emptyArray
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSort_EmptyArray_Exception()
        {
            int[] array = new int[] { };
            ArraySorts.Quicksort(ref array, 1, 2);
        }

        /// <summary>
        /// One element
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Quicksort_OneNumberOfArray_ThisNumber()
        {
            int[] array = new int[] { };
            ArraySorts.Quicksort(ref array, 1, 2);
        }

        /// <summary>
        /// Null array
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_NullArrayException()
        {
            int[] array = null;
            ArraySorts.Quicksort(ref array, 1, 2);
        }
        #endregion
        #region MergeSortTests definition
        /// <summary>
        /// Checks if arrays are equal
        /// </summary>
        [TestMethod]
        public void MergeSort_unsortedarray136254_sortedarray123456()
        {
            // Arrange Act Assert (AAA) Pattern

            // Arrange
            int[] intarr = new int[6] { 1, 6, 3, 8, 5, 4 };
            int[] expectedarr = new int[6] { 1, 3, 4, 5, 6, 8 };

            // Act
            ArraySorts.MergeSort(ref intarr, 0, intarr.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expectedarr, intarr);
        }

        /// <summary>
        /// Test emptyArray
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_EmptyArray_Exception()
        {
            int[] array = new int[] { };
            ArraySorts.MergeSort(ref array, 1, 2);
        }

        /// <summary>
        /// One element
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_OneNumberOfArray_ThisNumber()
        {
            int[] array = new int[] { };
            ArraySorts.MergeSort(ref array, 1, 2);
        }

        /// <summary>
        /// Null array
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_NullArrayException()
        {
            int[] array = null;
            ArraySorts.MergeSort(ref array, 1, 2);
        }

        /// <summary>
        /// Very big array(stop working around 100M and 200M elements of array)
        /// </summary>
        [TestMethod]
        public void MergeSort_BigArray_SortedArray()
        {
            Random rand = new Random();

            // Arr
            int[] array = new int[100000001];
            int[] expected = new int[100000001];
            for (int i = 0; i < expected.Length - 1; i++)
            {
                expected[i] = rand.Next(1000000);
            }

            // Act
            ArraySorts.MergeSort(ref array, 0, array.Length - 1);

            // Assert
            if (!ArraySorts.IsSort(array))
            {
                Assert.Fail();
            }
        }
        #endregion
    }
}