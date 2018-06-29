// <copyright file = "ArraySortTests.cs" company = "EPAM">
// Array Sort Tests
// </copyright>
using System;
using NUnit.Framework;

namespace InsertNumber.NUnit.Tests
{
    /// <summary>
    /// NUnit Tests for Insert Number
    /// </summary>
    [TestFixture]
    public class InsertNumberNUnitTests
    {
        #region Check if the number is correct
        /// <summary>
        /// Check if the number is correct
        /// </summary>
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int InsertBinaryNumbers_Input8and15_Output120(int firstNumber, int secondNumber, int i, int j)
            => InsertNumber.InsertBinaryNumbers(firstNumber, secondNumber, i, j);
        #endregion
        #region Check if the number is correct 2
        /// <summary>
        /// Check if the number is correct 2
        /// </summary>
        [TestCase(10, 11, 3, 8, ExpectedResult = 90)]
        public int InsertBinaryNumbers_Input10and11_Output90(int firstNumber, int secondNumber, int i, int j)
            => InsertNumber.InsertBinaryNumbers(firstNumber, secondNumber, i, j);
        #endregion
        #region Check creating number width 0
        /// <summary>
        /// Check creating number width 0
        /// </summary>
        [TestCase(0, 14, 2, 5, ExpectedResult = 56)]
        public int InsertBinaryNumbers_Input0and14_Output56(int firstNumber, int secondNumber, int i, int j)
            => InsertNumber.InsertBinaryNumbers(firstNumber, secondNumber, i, j);
        #endregion
    }
}
