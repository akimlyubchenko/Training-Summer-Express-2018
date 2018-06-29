// <copyright file = "ArraySortTests.cs" company = "EPAM">
// Array Sort Tests
// </copyright>
namespace ArraySort.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///  Tests for Array sort
    /// </summary>
    [TestClass]
    public class ArraySortTests
    {
        #region Checker arrays
        /// <summary>
        /// Checker arrays
        /// </summary>
        [TestMethod]
        public void FilterDigit_InputArray1217157_Return177()
        {
            // Arr
            int[] arr = { 12, 17, 10, 7 };
            int[] expected = { 17, 7 };

            // Arc
            int[] actual = ArraySort.FilterDigit(arr, 7);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion
        #region Checker arrays width value == 0
        /// <summary>
        /// Checker arrays width value == 0
        /// </summary>
        [TestMethod]
        public void FilterDigit_InputValue0_NumbersWidth0()
        {
            // Arr
            int[] arr = { 12, 0, 15, 105, 10456 };
            int[] expected = { 0, 105, 10456 };

            // Arc
            int[] actual = ArraySort.FilterDigit(arr, 0);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion
        #region Checker negative numbers
        /// <summary>
        /// Checker negative numbers
        /// </summary>
        [TestMethod]
        public void FilterDigit_Inputnegativenumbers_ReturnSuitableNumbers()
        {
            // Arr
            int[] arr = { -12, -17, -20, 7 };
            int[] expected = { -12, -20 };

            // Arc
            int[] actual = ArraySort.FilterDigit(arr, 2);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion
        #region Checker for null array
        /// <summary>
        /// Checker for null array
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_NullInsteadArray_ThrowArgumentNullException()
                => ArraySort.FilterDigit(null, 0);
        #endregion
    }
}
