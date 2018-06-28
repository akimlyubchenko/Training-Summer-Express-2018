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
        #region QuickSort definition
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
        #endregion

        #region MergeSort definition
        /// <summary>
        /// Merge sort method
        /// </summary>
        /// <param name="unsortedArray"> Input array </param>
        /// <param name="leftIndex"> Input first element</param>
        /// <param name="rightIndex"> Input last element </param>
        /// <returns> Complete array </returns>
        public static int[] MergeSort(int[] unsortedArray, int leftIndex, int rightIndex)
        {
            if (unsortedArray == null)
            {
                throw new ArgumentNullException(nameof(unsortedArray));
            }

            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                MergeSort(unsortedArray, leftIndex, middleIndex);
                MergeSort(unsortedArray, middleIndex + 1, rightIndex);
                Merge(unsortedArray, leftIndex, middleIndex, rightIndex);
            }

            return unsortedArray;
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
        #endregion
    }
}
