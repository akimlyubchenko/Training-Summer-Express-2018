using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    /// <summary>
    /// Convert double numbers to binary
    /// </summary>
    public static class DoubleToBinary
    {
        /// <summary>
        /// Doubles to binary converter
        /// </summary>
        /// <param name="number"> The number </param>
        /// <returns> Number in binaty </returns>
        public static string DoubleToBinaryString(this double number)
        {
            DoubleToLong value = new DoubleToLong { double64bits = number };

            // Можно хоть в строку конвертировать?)
            return String.Concat(Converter(value));
        }

        /// <summary>
        /// Fills up array
        /// </summary>
        /// <param name="value"> The value </param>
        /// <returns> Done array binary numbers </returns>
        private static byte[] Converter(DoubleToLong value)
        {
            byte[] doneNumber = new byte[64];
            long mask = 1L;
            for (int i = 0; i < 64; i++)
            {
                if ((value.long64bits & mask) == 0)
                {
                    doneNumber[doneNumber.Length - 1 - i] = 0;
                }
                else
                {
                    doneNumber[doneNumber.Length - 1 - i] = 1;
                }

                mask <<= 1;
            }
            return doneNumber;
        }

        /// <summary>
        /// Struct for read bytes from double
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLong
        {
            [FieldOffset(0)]
            public readonly long long64bits;
            [FieldOffset(0)]
            public double double64bits;
        }


    }
}
