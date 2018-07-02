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
        #region QuickSortRunnerTests definition
        /// <summary>
        /// Very big array(stop working around 100M and 200M elements of array)
        /// </summary>
        [TestMethod]
        public void QuickSortRunner_BigArray_SortedArray()
        {
            // Arr
            int[] array = new int[100];

            // Act
            ArraySorts.QuickSortRunner(array, 0, array.Length - 1);

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
        public void QuickSortRunner_unsortedarray163854_sortedarray134568()
        {
            // Arrange
            int[] intarr = new int[6] { 1, 6, 3, 8, 5, 4 };
            int[] expectedarr = new int[6] { 1, 3, 4, 5, 6, 8 };

            // Act
            ArraySorts.QuickSortRunner(intarr, 0, intarr.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expectedarr, intarr);
        }

        /// <summary>
        /// Test emptyArray
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSortRunner_EmptyArray_Exception()
        {
            int[] array = new int[] { };
            ArraySorts.QuickSortRunner(array, 1, 2);
        }

        /// <summary>
        /// One element
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSortRunner_OneNumberOfArray_ThisNumber()
        {
            int[] array = new int[] { };
            ArraySorts.QuickSortRunner(array, 1, 2);
        }

        /// <summary>
        /// Null array
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSortRunner_NullArrayException()
        {
            int[] array = null;
            ArraySorts.QuickSortRunner(array, 1, 2);
        }
        #endregion
        #region MergeSortRunnerTests definition
        /// <summary>
        /// Checks if arrays are equal
        /// </summary>
        [TestMethod]
        public void MergeSortRunner_unsortedarray136254_sortedarray123456()
        {
            // Arrange Act Assert (AAA) Pattern

            // Arrange
            int[] intarr = new int[6] { 1, 6, 3, 8, 5, 4 };
            int[] expectedarr = new int[6] { 1, 3, 4, 5, 6, 8 };

            // Act
            ArraySorts.MergeSortRunner(intarr, 0, intarr.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expectedarr, intarr);
        }

        /// <summary>
        /// Test emptyArray
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSortRunner_EmptyArray_Exception()
        {
            int[] array = new int[] { };
            ArraySorts.MergeSortRunner(array, 1, 2);
        }

        /// <summary>
        /// One element
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSortRunner_OneNumberOfArray_ThisNumber()
        {
            int[] array = new int[] { };
            ArraySorts.MergeSortRunner(array, 1, 2);
        }

        /// <summary>
        /// Null array
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSortRunner_NullArrayException()
        {
            int[] array = null;
            ArraySorts.MergeSortRunner(array, 1, 2);
        }

        /// <summary>
        /// Very big array(stop working around 100M and 200M elements of array)
        /// </summary>
        [TestMethod]
        public void MergeSortRunner_BigArray_SortedArray()
        {
            Random rand = new Random();

            // Arr
            int[] array = new int[100];
            int[] expected = new int[100];
            for (int i = 0; i < expected.Length - 1; i++)
            {
                expected[i] = rand.Next(100);
            }

            // Act
            ArraySorts.MergeSortRunner(array, 0, array.Length - 1);

            // Assert
            if (!ArraySorts.IsSort(array))
            {
                Assert.Fail();
            }
        } 
        #endregion
    }
}