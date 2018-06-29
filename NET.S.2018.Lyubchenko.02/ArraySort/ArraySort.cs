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
        /// <param name="arr"> Input array </param>
        /// <param name="value"> Searcher value </param>
        /// <returns> Output array </returns>
        public static int[] FilterDigit(int[] arr, int value)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            int[] newarr = new int[arr.Length];
            int count = 0;
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 0)
                    {
                        newarr[count] = arr[i];
                        count++;
                        i++;
                    }

                    int temp = arr[i];
                    while (temp % 10 != 0 || temp / 10 != 0)
                    {
                        if (temp % 10 == value || -temp % 10 == value)
                        {
                            newarr[count] = arr[i];
                            count++;
                            break;
                        }

                        temp = temp / 10;
                    }
                }

                int[] finisharr = new int[count];
                for (int i = 0; i < finisharr.Length; i++)
                {
                    finisharr[i] = newarr[i];
                }

                return finisharr;
            }
        }
        #endregion
    }
}
