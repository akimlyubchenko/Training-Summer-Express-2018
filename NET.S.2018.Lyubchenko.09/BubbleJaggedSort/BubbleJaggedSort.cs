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
        public static void BubbleSort(int[][] array, Comparison<int[]> comp)
        {
            Validator(array, comp);
            bool temp = false;
            while (!temp)
            {
                temp = true;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (comp.Invoke(array[i], array[i + 1]) > 0)
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        temp = false;
                    }
                }
            }
        }

        private static void Validator(int[][] array, Comparison<int[]> comp)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} must contain numbers");
            }

            if (comp == null)
            {
                throw new ArgumentNullException($"Transfer method");
            }
        }

        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] temp = rhs;
            rhs = lhs;
            lhs = temp;
        }
    }
}
