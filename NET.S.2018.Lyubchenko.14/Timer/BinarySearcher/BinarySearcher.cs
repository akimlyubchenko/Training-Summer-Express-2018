using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearcher
{
    /// <summary>
    /// Searcher through binary method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class BinarySearcher<T>
    {
        /// <summary>
        /// Searcher through binary method
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="reqNumber">The required number.</param>
        /// <param name="comp">The delegate</param>
        /// <returns> Index of required number </returns>
        public static int RequiredNumber(T[] array, T reqNumber, Comparison<T> comp)
        {
            Validator(array, reqNumber, comp);
            return Searcher(array, reqNumber, 0, array.Length - 1, comp);
        }

        private static int Searcher(T[] array, T reqNumber, int start, int end, Comparison<T> comp)
        {
            int mid = (start + end) / 2;
            if (comp.Invoke(array[mid], reqNumber) > 0)
            {
                mid = Searcher(array, reqNumber, start, mid, comp);
            }
            else if (comp.Invoke(array[mid], reqNumber) < 0)
            {
                mid = Searcher(array, reqNumber, mid + 1, end, comp);
            }

            if (comp.Invoke(array[mid], reqNumber) == 0)
            {
                return mid;
            }

            return -1;
        }

        private static void Validator(T[] array, T reqNumber, Comparison<T> comp)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Fill array");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Enter at least 1 number");
            }

            if (reqNumber == null)
            {
                throw new ArgumentNullException("Fill Number");
            }

            if (comp == null)
            {
                throw new ArgumentNullException("Fill comparison");
            }

            if (comp.Invoke(array[0], reqNumber) > 0 || comp.Invoke(array[array.Length - 1], reqNumber) < 0)
            {
                throw new ArgumentException($"Required number must be more than arr[0] and less than arr[length]");
            }
        }
    }
}
