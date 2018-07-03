using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearestNumberCalculator
{
    /// <summary>
    /// Finder next bigger number
    /// </summary>
    public class NearestNumberCalculator
    {
        #region public API
        /// <summary>
        /// Finder next bigger number
        /// </summary>
        /// <param name="number"> The original number </param>
        /// <returns> Final number </returns>
        public static int FindNextBiggerNumber(int number)
        {
            Exception(number);
            int digitCount = (int)Math.Log10(number) + 1;
            int[] array = new int[digitCount];
            for (int i = 0; i < array.Length; i++)
            {
                array[array.Length - i - 1] = number % 10;
                number /= 10;
            }

            return ProcessingArray(array, number);
        }
        #endregion

        #region private API
        private static int ProcessingArray(int[] array, int number)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i - 1] < array[i])
                {
                    Swap(ref array[i - 1], ref array[i]);
                    Quicksort(array, i, array.Length - 1);
                    for (int j = 0; j < array.Length; j++)
                    {
                        number += array[j];
                        if (j != array.Length - 1)
                        {
                            number *= 10;
                        }
                    }

                    return number;
                }
            }

            return -1;
        }

        /// <summary>
        /// Accepts an array for further processing
        /// </summary>
        /// <param name="array"> Input array </param>
        /// <param name="start"> Input start index </param>
        /// <param name="end"> Input last index </param>
        /// <returns> The right array </returns>
        private static void Quicksort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(array, start, end);
                if (pivot > 1)
                {
                    Quicksort(array, start, pivot - 1);
                }

                if (pivot + 1 < end)
                {
                    Quicksort(array, pivot + 1, end);
                }
            }
        }

        /// <summary>
        /// Sort part between start and end
        /// </summary>
        /// <param name="array">Input array</param>
        /// <param name="start">Input start index</param>
        /// <param name="end">Input last index</param>
        /// <returns> Index of partition </returns>
        private static int Partition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    Swap(ref array[marker], ref array[i]);
                    marker++;
                }
            }

            Swap(ref array[marker], ref array[end]);
            return marker;
        }

        /// <summary>
        /// Swap 2 integer elements
        /// </summary>
        /// <param name="one"> It's first element </param>
        /// <param name="two"> It's second element </param>
        private static void Swap(ref int one, ref int two)
        {
            int temp;
            temp = one;
            one = two;
            two = temp;
        }

        /// <summary>
        /// If number is valid
        /// </summary>
        /// <param name="number"> Number </param>
        /// <exception cref="ArgumentException"> 
        /// number less than 1 
        /// </exception>
        private static void Exception(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"Number {number} is negative");
            }
        }
        #endregion
    }
}
