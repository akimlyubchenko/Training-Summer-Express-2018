using System;

namespace BubbleJaggedSort
{
    /// <summary>
    /// Bubble Jagged Sort
    /// </summary>
    public static class BubbleJaggedSort
    {
        /// <summary>
        /// Bubble Jagged Sort
        /// </summary>
        /// <param name="array"> The start array </param>
        /// <param name="format"> The format </param>
        /// <returns> Sortted array </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Appears if any array == null
        /// </exception>
        public static int[][] BubbleSort(int[][] array, int format = 1)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    throw new ArgumentNullException("Arrays must contain any numbers");
                }
            }

            switch (format)
            {
                case 1:
                    return SumSort(array);
                case 2:
                    return MaxElSort(array);
                case 3:
                    return Inverse(MinElSort(array));
                case 4:
                    return Inverse(SumSort(array));
                case 5:
                    return Inverse(MaxElSort(array));
                case 6:
                    return MinElSort(array);
                default:
                    return SumSort(array);
            }
        }

        /// <summary>
        /// Sort array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="tempArray">The temporary array.</param>
        private static void BubbleSort(int[][] array, int[] tempArray)
        {
            int temp = -1;
            while (temp != 0)
            {
                temp = 0;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (tempArray[i] > tempArray[i + 1])
                    {
                        Swap(ref tempArray[i], ref tempArray[i + 1]);
                        Swap(ref array[i], ref array[i + 1]);
                        temp++;
                    }
                }
            }
        }

        /// <summary>
        /// Sums the array
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns> Sorted array </returns>
        private static int[][] SumSort(int[][] array)
        {
            BubbleSort(array, SumHelper(array));
            return array;
        }

        /// <summary>
        /// Sums the helper.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns> array width sum elements </returns>
        private static int[] SumHelper(int[][] array)
        {
            int[] sumTemp = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sumTemp[i] += array[i][j];
                }
            }

            return sumTemp;
        }

        /// <summary>
        /// Max element in array 
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns> Sorted array </returns>
        private static int[][] MaxElSort(int[][] array)
        {
            BubbleSort(array, MaxElHelper(array));
            return array;
        }

        /// <summary>
        /// array of max el-s
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns> array of max el-s </returns>
        private static int[] MaxElHelper(int[][] array)
        {
            int[] maxElTemp = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                maxElTemp[i] = array[i][0];
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    if (maxElTemp[i] < array[i][j + 1])
                    {
                        maxElTemp[i] = array[i][j + 1];
                    }
                }
            }

            return maxElTemp;
        }

        /// <summary>
        /// Min elements in arrays 
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns> Sorted array </returns>
        private static int[][] MinElSort(int[][] array)
        {
            BubbleSort(array, MaxElHelper(MinElHelper(array)));
            return array;
        }

        /// <summary>
        /// Temp array width negative elements
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns> Temp array width negative elements </returns>
        private static int[][] MinElHelper(int[][] array)
        {
            int[][] tempArr = new int[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                tempArr[i] = new int[array[i].Length];
                for (int j = 0; j < array[i].Length; j++)
                {
                    tempArr[i][j] = array[i][j] * (-1);
                }
            }

            return tempArr;
        }

        /// <summary>
        /// Inverses the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns> Convert array </returns>
        private static int[][] Inverse(int[][] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                Swap(ref array[i], ref array[array.Length - i - 1]);
            }

            return array;
        }

        /// <summary>
        /// Swaps the specified integers.
        /// </summary>
        /// <param name="lhs">The first int.</param>
        /// <param name="rhs">The second int.</param>
        private static void Swap(ref int lhs, ref int rhs)
        {
            int temp = rhs;
            rhs = lhs;
            lhs = temp;
        }

        /// <summary>
        /// Swaps the specified arrays.
        /// </summary>
        /// <param name="lhs">The first array.</param>
        /// <param name="rhs">The second array.</param>
        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] temp = rhs;
            rhs = lhs;
            lhs = temp;
        }
    }
}
