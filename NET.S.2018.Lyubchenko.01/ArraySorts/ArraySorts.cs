// <copyright file = "ArraySorts.cs" company = "EPAM">
// Sorts
// </copyright>
namespace ArraySorts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 2 sorts: QuickSort and MergeSort
    /// </summary>
    public class ArraySorts
    {
        #region public API
        /// <summary>
        /// Run QuickSort method or give exception if the parameters are incorrect
        /// </summary>
        /// <param name="array"> Input array </param>
        /// <param name="start"> Input start index </param>
        /// <param name="end"> Input last index </param>
        public static void QuickSort(int[] array, int start, int end)
        {
            IsValid(array, start, end);
            Quicksort(array, start, end);
        }

        /// <summary>
        /// Run MergeSort method or give exception if the parameters are incorrect
        /// </summary>
        /// <param name="unsortedArray"> Input array </param>
        /// <param name="leftIndex"> Input first element</param>
        /// <param name="rightIndex"> Input last element </param>
        public static void MergeSort(int[] unsortedArray, int leftIndex, int rightIndex)
        {
            IsValid(unsortedArray, leftIndex, rightIndex);
            MergeSort(unsortedArray, leftIndex, rightIndex);
        }
        #endregion
        #region private API
        /// <summary>
        /// Accepts an array for further processing
        /// </summary>
        /// <param name="array"> Input array </param>
        /// <param name="start"> Input start index </param>
        /// <param name="end"> Input last index </param>
        /// <returns> The right array </returns>
        private static void QuicksortRealization(int[] array, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(array, start, end);
                if (pivot > 1)
                {
                    QuicksortRealization(array, start, pivot - 1);
                }

                if (pivot + 1 < end)
                {
                    QuicksortRealization(array, pivot + 1, end);
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
        /// Merge sort method
        /// </summary>
        /// <param name="unsortedArray"> Input array </param>
        /// <param name="leftIndex"> Input first element</param>
        /// <param name="rightIndex"> Input last element </param>
        /// <returns> Complete array </returns>
        private static void MergeSortRealization(int[] unsortedArray, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                MergeSortRealization(unsortedArray, leftIndex, middleIndex);
                MergeSortRealization(unsortedArray, middleIndex + 1, rightIndex);
                Merge(unsortedArray, leftIndex, middleIndex, rightIndex);
            }
        }

        /// <summary>
        /// Sorts parts of an array
        /// </summary>
        /// <param name="unsortedArray"> Input array </param>
        /// <param name="leftIndex"> Input first element</param>
        /// <param name="middleIndex"> Input middle index </param>
        /// <param name="rightIndex"> Input last element </param>
        private static void Merge(int[] unsortedArray, int leftIndex, int middleIndex, int rightIndex)
        {
            int lengthLeft = middleIndex - leftIndex + 1;
            int lengthRight = rightIndex - middleIndex;
            int[] leftArray = new int[lengthLeft + 1];
            int[] rightArrray = new int[lengthRight + 1];
            for (int i = 0; i < lengthLeft; i++)
            {
                leftArray[i] = unsortedArray[leftIndex + i];
            }

            for (int j = 0; j < lengthRight; j++)
            {
                rightArrray[j] = unsortedArray[middleIndex + j + 1];
            }

            leftArray[lengthLeft] = int.MaxValue;
            rightArrray[lengthRight] = int.MaxValue;
            int start = 0;
            int end = 0;

            for (int k = leftIndex; k <= rightIndex; k++)
            {
                if (leftArray[start] <= rightArrray[end])
                {
                    unsortedArray[k] = leftArray[start];
                    start++;
                }
                else
                {
                    unsortedArray[k] = rightArrray[end];
                    end++;
                }
            }
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
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="leftIndex">Index of the left.</param>
        /// <param name="rightIndex">Index of the right.</param>
        /// <exception cref="ArgumentNullException"> Array mustn't be null</exception>
        /// <exception cref="ArgumentException">
        /// array lenght mustn't be equal 1 or 0
        /// Start index must be greater than end index
        /// </exception>
        private static void IsValid(int[] array, int leftIndex = 0, int rightIndex = 1)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0 || array.Length == 1)
            {
                throw new ArgumentException(nameof(array));
            }

            if (leftIndex >= rightIndex)
            {
                throw new ArgumentException($"Start index must be greater than end index");
            }
        }
        #endregion
    }
}
