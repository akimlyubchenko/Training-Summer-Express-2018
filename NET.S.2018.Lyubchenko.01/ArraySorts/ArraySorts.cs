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
        public static void Quicksort(ref int[] array, int start, int end)
        {
            IsValid(array, start, end);

            if (start < end)
            {
                int pivot = Partition(array, start, end);
                if (pivot > 1)
                {
                    Quicksort(ref array, start, pivot - 1);
                }

                if (pivot + 1 < end)
                {
                    Quicksort(ref array, pivot + 1, end);
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
        #endregion

        #region MergeSort definition
        /// <summary>
        /// Merge sort method
        /// </summary>
        /// <param name="unsortedArray"> Input array </param>
        /// <param name="leftIndex"> Input first element</param>
        /// <param name="rightIndex"> Input last element </param>
        /// <returns> Complete array </returns>
        public static void MergeSort(ref int[] unsortedArray, int leftIndex, int rightIndex)
        {
            IsValid(unsortedArray, leftIndex, rightIndex);

            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                MergeSort(ref unsortedArray, leftIndex, middleIndex);
                MergeSort(ref unsortedArray, middleIndex + 1, rightIndex);
                Merge(ref unsortedArray, leftIndex, middleIndex, rightIndex);
            }
        }

        /// <summary>
        /// Sorts parts of an array
        /// </summary>
        /// <param name="unsortedArray"> Input array </param>
        /// <param name="leftIndex"> Input first element</param>
        /// <param name="middleIndex"> Input middle index </param>
        /// <param name="rightIndex"> Input last element </param>
        private static void Merge(ref int[] unsortedArray, int leftIndex, int middleIndex, int rightIndex)
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
        /// <summary>
        /// Checked if array sort
        /// </summary>
        /// <param name="array"> Array </param>
        /// <returns> True if sort, false if not </returns>
        public static bool IsSort(int[] array)
        {
            for (int i = 0; i < array.Length - 2; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }

            return true;
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
        /// Validator
        /// </summary>
        /// <param name="array"> Input array </param>
        /// <param name="leftIndex"> Left index </param>
        /// <param name="rightIndex"> Right index </param>
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
        }
    }
}
