// <copyright file = "QuickSort.cs" company = "EPAM">
// QuickSort
// </copyright>
namespace QuickSort
{
    using System;

    /// <summary>
    /// Sort array
    /// </summary>
    public class QuickSort
    { 
        /// <summary>
        /// Accepts an array for further processing
        /// </summary>
        /// <param name="array"> Input array </param>
        /// <param name="start"> Input start index </param>
        /// <param name="end"> Input last index </param>
        /// <returns> The right array </returns>
        public static int[] Quicksort(int[] array, int start, int end)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

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

            return array;
        }

        /// <summary>
        /// Swap 2 integer elements
        /// </summary>
        /// <param name="one"> It's first element </param>
        /// <param name="two"> It's second element </param>
        public static void Swap(ref int one, ref int two)
        {
            int temp;
            temp = one;
            one = two;
            two = temp;
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
    }
}
