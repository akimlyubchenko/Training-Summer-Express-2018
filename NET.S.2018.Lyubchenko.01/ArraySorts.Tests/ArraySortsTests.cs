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
        /// Checks if arrays are equal
        /// </summary>
        [TestMethod]
        public void Quicksort_unsortedarray163854_sortedarray134568()
        {
            // Arrange
            int[] intarr = new int[6] { 1, 6, 3, 8, 5, 4 };
            int[] expectedarr = new int[6] { 1, 3, 4, 5, 6, 8 };

            // Act
            int[] actualarr = new int[6];
            actualarr = ArraySorts.Quicksort(intarr, 0, intarr.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expectedarr, actualarr);
        }

        /// <summary>
        /// Checks if array are null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Quicksort_nullInsteadArray_ThrowArgumentNullException()
                => ArraySorts.Quicksort(null, 0, 1);

        /// <summary>
        /// Checks if array are equal 1
        /// </summary>
        [TestMethod]
        public void Quicksort_OneNumberOfArray_ThisNumber()
        {
            // Arr
            int[] arr = new int[1] { 5 };
            int[] expectedarr = new int[1] { 5 };

            // Act
            int[] actualarr = ArraySorts.Quicksort(arr, 0, arr.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expectedarr, actualarr);
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
        int[] actualarr = new int[6];
        actualarr = ArraySorts.MergeSort(intarr, 0, intarr.Length - 1);

        // Assert
        CollectionAssert.AreEqual(expectedarr, actualarr);
    }

    /// <summary>
    /// Checks if array are null
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void MergeSort_nullInsteadArray_ThrowArgumentNullException()
            => ArraySorts.MergeSort(null, 0, 1);

    /// <summary>
    /// Checks if array are equal 1
    /// </summary>
    [TestMethod]
    public void MergeSort_OneNumberOfArray_ThisNumber()
    {
        // Arr
        int[] arr = new int[1] { 5 };
        int[] expectedarr = new int[1] { 5 };

        // Act
        int[] actualarr = ArraySorts.MergeSort(arr, 0, arr.Length - 1);

        // Assert
        CollectionAssert.AreEqual(expectedarr, actualarr);
    }
        #endregion
    }
}