using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public static class Converter
    {
        #region public API
        public static string IEEEConverter(this double number)
        {
            int intNumber = (int)number;
            int[] array = new int[64];
            if (number >= 0.0)
            {
                array[0] = 0;
            }
            else
            {
                array[0] = 1;
            }
            // Add binary number 
            int[] intermediateArray = InBinary(intNumber);
            SavingArray(array, intermediateArray, 12);
            int mantissa = intermediateArray.Length;

            intermediateArray = NumbersAfterPoint(number, 52 - mantissa);
            SavingArray(array, intermediateArray, 12 + mantissa);

            intermediateArray = InBinary(mantissa + 1022);
            SavingArray(array, intermediateArray, 1);

            return String.Concat(array);
        }
        #endregion

        #region private API
        private static int[] InBinary(int number)
        {
            List<int> binaryNumbers = new List<int>();
            int intPartCounter = 0;
            while (number != 0)
            {
                binaryNumbers.Add(number % 2);
                number /= 2;
                intPartCounter++;
            }

            int[] doneArray = new int[intPartCounter];
            for (int i = 0; i < intPartCounter; i++)
            {
                doneArray[intPartCounter - 1 - i] = binaryNumbers[i];
            }
            return doneArray;
        }

        private static void SavingArray(int[] actualArray, int[] intermediateArray, int index)
        {
            for (int i = 0; i < intermediateArray.Length; i++)
            {
                actualArray[index + i] = intermediateArray[i];
            }
        }

        private static int[] NumbersAfterPoint(double doubleNumber, int emptyCells)
        {
            decimal number = (decimal)doubleNumber;
            number = number % 1;
            int[] rest = new int[emptyCells];
            for (int i = 0; i < emptyCells; i++)
            {
                number *= 2;
                if (number > 1)
                {
                    rest[i] = 1;
                    number -= 1;
                }
                else
                {
                    rest[i] = 0;
                }

            }

            return rest;
        }
        #endregion
    }
}
