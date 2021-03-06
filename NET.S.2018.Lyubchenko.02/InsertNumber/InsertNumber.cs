﻿// <copyright file = "InsertNumber.cs" company = "EPAM">
// Compute and insert j-i elements
// </copyright>
namespace InsertNumber
{
    using System;
    /// <summary>
    /// Compute and insert j-i elements in finish number
    /// </summary>
    public class InsertNumber
    {
        #region Compute and insert j-i elements in finish number
        /// <summary>
        /// Compute and insert j-i elements in finish number
        /// </summary>
        /// <param name="firstNumber"> First number </param>
        /// <param name="secondNumber"> Second number </param>
        /// <param name="i"> Start index </param>
        /// <param name="j"> End index </param>
        /// <returns> Finish value </returns>
        public static int InsertBinaryNumbers(int firstNumber, int secondNumber, int i, int j)
        {
            // Create place for j-i numbers
            int temp = (1 << (j - 1 + 1)) - 1;

            // Copy secondNumber
            temp &= secondNumber;

            // Create place for firstNumber
            temp <<= i;

            // Create new temp and create place to it
            int temp2 = 1;
            temp2 <<= i;
            temp2 -= 1;

            // Copy i-1 numbers from firstNumber
            temp2 &= firstNumber;

            // Contain together and return finish number
            return temp | temp2;
        }

        private static void IsValid()
        {
            if (i > j)
            {
                throw new ArgumentException($"Enter i > j");
            }
        }
        #endregion
    }
}
