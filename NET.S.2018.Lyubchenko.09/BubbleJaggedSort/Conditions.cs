using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditions
{
    /// <summary>
    /// Sum 2 arrays
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
    public class Sum : IComparer<int[]>
    {
        /// <summary>
        /// Compares 2 arrays
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns> Positive if lhs > 0 </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return 0;
            }

            if (lhs == null)
            {
                return -1;
            }

            if (rhs == null)
            {
                return 1;
            }

            return Helpers.SumHelper(lhs) - Helpers.SumHelper(rhs);
        }
    }

    /// <summary>
    /// InverseSum 2 arrays
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
    public class InverseSum : IComparer<int[]>
    {
        /// <summary>
        /// Compares 2 arrays
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns> Positive if lhs > 0 </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return 0;
            }

            if (lhs == null)
            {
                return 1;
            }

            if (rhs == null)
            {
                return -1;
            }

            return Helpers.SumHelper(rhs) - Helpers.SumHelper(lhs);
        }
    }

    /// <summary>
    /// Min el of 2 arrays
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
    public class Min : IComparer<int[]>
    {
        /// <summary>
        /// Compares 2 arrays
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns> Positive if lhs > 0 </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return 0;
            }

            if (lhs == null)
            {
                return -1;
            }

            if (rhs == null)
            {
                return 1;
            }

            return Helpers.MinHelper(lhs) - Helpers.MinHelper(rhs);
        }
    }

    /// <summary>
    /// InverseMin el for 2 arrays
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
    public class InverseMin : IComparer<int[]>
    {
        /// <summary>
        /// Compares 2 arrays
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns> Positive if lhs > 0 </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return 0;
            }

            if (lhs == null)
            {
                return 1;
            }

            if (rhs == null)
            {
                return -1;
            }

            return Helpers.MinHelper(rhs) - Helpers.MinHelper(lhs);
        }
    }

    /// <summary>
    /// Max el of 2 arrays
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
    public class Max : IComparer<int[]>
    {
        /// <summary>
        /// Compares 2 arrays
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns> Positive if lhs > 0 </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return 0;
            }

            if (lhs == null)
            {
                return -1;
            }

            if (rhs == null)
            {
                return 1;
            }

            return Helpers.MaxHelper(lhs) - Helpers.MaxHelper(rhs);
        }
    }

    /// <summary>
    /// Inverse max of 2 arrays
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IComparer{System.Int32[]}" />
    public class InverseMax : IComparer<int[]>
    {
        /// <summary>
        /// Compares 2 arrays
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns> Positive if lhs > 0 </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return 0;
            }

            if (lhs == null)
            {
                return 1;
            }

            if (rhs == null)
            {
                return -1;
            }

            return Helpers.MaxHelper(rhs) - Helpers.MaxHelper(lhs);
        }
    }

    /// <summary>
    /// Helpers for operations
    /// </summary>
    internal static class Helpers
    {
        internal static int MaxHelper(int[] array)
        {
            int max = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }

            return max;
        }

        internal static int MinHelper(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }

            return min;
        }

        internal static int SumHelper(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
