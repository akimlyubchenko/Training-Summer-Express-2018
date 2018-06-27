// <copyright file = "MergerSortTests.cs" company = "EPAM">
//  MergerSortTests
// </copyright>
namespace MergerSort.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///  Tests Merger sort
    /// </summary>
    [TestClass]
    public class MergerSortTests
    {
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
            actualarr = MergerSort.MergeSort(intarr, 0, intarr.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expectedarr, actualarr);
        }

        /// <summary>
        /// Checks if array are null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_nullInsteadArray_ThrowArgumentNullException()
                => MergerSort.MergeSort(null, 0, 1);

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
            int[] actualarr = MergerSort.MergeSort(arr, 0, arr.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expectedarr, actualarr);
        }
    }
}
