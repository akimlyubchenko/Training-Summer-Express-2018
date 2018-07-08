using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public static class DoubleToBinary
    {
        public static string DoubleToBinaryString(this double number)
        {
            DoubleToLong value = new DoubleToLong { Double64bits = number };

            // Можно хоть в строку конвертировать?)
            return String.Concat(Converter(value));
        }

        private static byte[] Converter(DoubleToLong value)
        {
            byte[] doneNumber = new byte[64];
            long mask = 1L;
            for (int i = 0; i < 64; i++)
            {
                if ((value.Long64bits & mask) == 0)
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

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLong
        {
            [FieldOffset(0)]
            private readonly long long64bits;
            [FieldOffset(0)]
            private double double64bits;

            public long Long64bits { get { return long64bits; } }
            public double Double64bits
            {
                get { return double64bits; }
                set { double64bits = value; }
            }

        }
    }
}
