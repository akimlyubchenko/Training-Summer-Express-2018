// <copyright file = "InsertNumberTests.cs" company = "EPAM">
// Insert number tests
// </copyright>
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsertNumber.Tests
{
    /// <summary>
    /// Test for insert number
    /// </summary>
    [TestClass]
    public class InsertNumberTests
    {
        #region Check if the number is correct
        /// <summary>
        /// Check if the number is correct
        /// </summary>
        [TestMethod]
        public void InsertBinaryNumbers_Input8and15_Output120()
        {
            // Arr
            int j = 8, i = 3;
            int firstNumber = 8, secondNumber = 15;
            int expectedNumber = 120;

            // Act
            int actual = InsertNumber.InsertBinaryNumbers(firstNumber, secondNumber, i, j);

            // Assert
            Assert.AreEqual(expectedNumber, actual);
        }
        #endregion
        #region Check if the number is correct 2
        /// <summary>
        /// Check if the number is correct 2
        /// </summary>
        [TestMethod]
        public void InsertBinaryNumbers_Input10and11_Output90()
        {
            // Arr
            int i = 3, j = 8;
            int firstNumber = 10, secondNumber = 11;
            int expectedNumber = 90;

            // Act
            int actual = InsertNumber.InsertBinaryNumbers(firstNumber, secondNumber, i, j);

            // Assert
            Assert.AreEqual(expectedNumber, actual);
        }
        #endregion
        #region Check creating number width 0
        /// <summary>
        /// Check creating number width 0
        /// </summary>
        [TestMethod]
        public void InsertBinaryNumbers_Input0and14_Output28()
        {
            // Arr
            int i = 2, j = 5;
            int firstNumber = 0, secondNumber = 14;
            int expectedNumber = 56;

            // Act
            int actual = InsertNumber.InsertBinaryNumbers(firstNumber, secondNumber, i, j);

            // Assert
            Assert.AreEqual(expectedNumber, actual);
        }
        #endregion
    }
}
