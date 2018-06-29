// <copyright file = "ArraySortTests.cs" company = "EPAM">
// Array Sort Tests
// </copyright>

namespace ArraySort.NunitTests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    ///  Tests for Array sort
    /// </summary>
    [TestFixture]
    public class ArraySortNunitTests
    {
        /// <summary>
        /// Checker arrays
        /// </summary>
        [TestCase(new int[] { 12, 17, 20, 7654321 }, 7, ExpectedResult = new int[] { 17, 7654321 })]
        public int[] FilterDigit_Input1217207654321_Return177654321(int[] arr, int value)
            => ArraySort.FilterDigit(arr, value);

        /// <summary>
        /// Checker negative numbers
        /// </summary>
        [TestCase(new int[] { -12, -17, -20, 7 }, 2, ExpectedResult = new int[] { -12, -20 })]
        public int[] FilterDigit_NegativeNumbers_SelectSuitableNumbers(int[] arr, int value)
            => ArraySort.FilterDigit(arr, value);

        /// <summary>
        /// Checker arrays width value == 0
        /// </summary>
        [TestCase(new int[] { -12, 0, -20, 7 }, 0, ExpectedResult = new int[] { 0, -20 })]
        public int[] FilterDigit_NumbersContain0_ReturnNumbersContain0(int[] arr, int value)
            => ArraySort.FilterDigit(arr, value);

        /// <summary>
        /// Checker for null array
        /// </summary>
        [Test]
        public void FilterDigit_WithNullArray_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => ArraySort.FilterDigit(null, 7));
    }
}
