// <copyright file = "ArraySort.cs" company = "EPAM">
// Array Sort
// </copyright>
using System;

namespace ArraySort
{
    /// <summary>
    /// Searcher numbers contain value
    /// </summary>
    public class ArraySort
    {
        #region FilterDigit definition
        /// <summary>
        /// Searcher value in array
        /// </summary>
        /// <param name="inputArray"> Input array </param>
        /// <param name="findValue"> Searcher value </param>
        /// <returns> Output array </returns>
        public static int[] FilterDigit(int[] inputArray, int findValue)
        {
            IsValid(inputArray, findValue);
            int count = 0;
            int[] newArray = new int[inputArray.Length];
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (findValue == 0 && inputArray[i] == 0)
                    {
                        newArray[count] = inputArray[i];
                        count++;
                        i++;
                    }

                    if (NumberFinder(inputArray[i], findValue))
                    {
                        newArray[count] = inputArray[i];
                        count++;
                    }
                }

            int[] finishArray = new int[count];
            for (int i = 0; i < finishArray.Length; i++)
            {
                finishArray[i] = newArray[i];
            }

            return finishArray;
        }

        /// <summary>
        /// Suitable numbers finder
        /// </summary>
        /// <param name="number"> It's element of array</param>
        /// <param name="findValue"> It's required number </param>
        /// <returns> True if number is suitable, false if not </returns>
        private static bool NumberFinder(int number, int findValue)
        {
            int temp = number;
            while (temp % 10 != 0 || temp / 10 != 0)
            {
                if (temp % 10 == findValue || -temp % 10 == findValue)
                {
                    return true;
                }

                temp = temp / 10;
            }

            return false;
        }


        /// <summary>
        /// The set of Exceptions
        /// </summary>
        /// <param name="number"> It's element of array</param>
        /// <param name="findValue"> It's required number </param>
        /// <exception cref="ArgumentException">
        /// If array length == 0
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// If array l== null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the value is greater than 9 or less than 0
        /// </exception>
        private static void IsValid(int[] inputArray, int findValue)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException(nameof(inputArray));
            }

            if (inputArray.Length == 0)
            {
                throw new ArgumentException(nameof(inputArray));
            }

            if (findValue < 0 || findValue > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(findValue));
            }
        }
    }
    #endregion

    
}
