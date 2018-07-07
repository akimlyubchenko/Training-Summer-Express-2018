using System;

namespace ToDecimal
{
    /// <summary>
    /// Converter number from any notation more 1 and less 17, to decimal number
    /// </summary>
    public static class ToDecimal
    {
        #region public API        
        /// <summary>
        /// Converter number from any notation more 1 and less 17, to decimal number
        /// </summary>
        /// <param name="numberString"> Entered number in string </param>
        /// <param name="notation"> The notation </param>
        /// <returns> Integer decimal number</returns>
        public static int ToDecimalConverter(string numberString, int notation)
        {
            IsValid(numberString, notation);
            int[] numbers = StringIntConvert(numberString, notation);
            return DoneNumber(numbers, notation);
        }
        #endregion

        #region private API        
        /// <summary>
        /// Works with a ready array of numbers
        /// </summary>
        /// <param name="numbers"> The ready array </param>
        /// <param name="notation"> The notation </param>
        /// <returns> A ready number </returns>
        private static int DoneNumber(int[] numbers, int notation)
        {
            int number = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                number += numbers[i] * (int)Math.Pow(notation, numbers.Length - 1 - i);
            }
            return number;
        }

        /// <summary>
        /// From string to int converter
        /// </summary>
        /// <param name="numberString"> Elementary string </param>
        /// <param name="notation"> The notation </param>
        /// <returns> Int array </returns>
        private static int[] StringIntConvert(string numberString, int notation)
        {
            if (notation > 10)
            {
                int[] numbers = StringIntConvertMoreDecimal(numberString);
                return numbers;
            }
            else
            {
                int[] numbers = new int[numberString.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = numberString[i] - 48;
                }

                return numbers;
            }
        }

        /// <summary>
        /// From string to int converter width notation more as 10
        /// </summary>
        /// <param name="numberString"> Elementary string </param>
        /// <returns> Int array </returns>
        private static int[] StringIntConvertMoreDecimal(string numberString)
        {
            int[] numbers = new int[numberString.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numberString[i] < 65)
                {
                    numbers[i] = numberString[i] - 48;
                }
                else if (numberString[i] == 65 || numberString[i] == 97)
                {
                    numbers[i] = 10;
                }
                else if (numberString[i] == 66 || numberString[i] == 98)
                {
                    numbers[i] = 11;
                }
                else if (numberString[i] == 67 || numberString[i] == 99)
                {
                    numbers[i] = 12;
                }
                else if (numberString[i] == 68 || numberString[i] == 100)
                {
                    numbers[i] = 13;
                }
                else if (numberString[i] == 69 || numberString[i] == 101)
                {
                    numbers[i] = 14;
                }
                else if (numberString[i] == 70 || numberString[i] == 102)
                {
                    numbers[i] = 15;
                }
            }

            return numbers;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="numberString"> Elementary string </param>
        /// <param name="notation"> The notation </param>
        /// <exception cref="ArgumentException">
        /// Notation or number are invalid
        /// </exception>
        /// <exception cref="ArgumentNullException"> Elementary number isn't valid </exception>
        private static void IsValid(string numberString, int notation)
        {
            if (notation < 2 || notation > 16)
            {
                throw new ArgumentException($"Notation is invalid");
            }

            if (numberString == null)
            {
                throw new ArgumentNullException(nameof(numberString));
            }

            for (int i = 0; i < numberString.Length; i++)
            {
                if (notation < 11)
                {
                    if (numberString[i] - 48 < 0 || numberString[i] - 48 > 9)
                    {
                        throw new ArgumentException($"Number is invalid");
                    }
                }
                else
                {
                    if (numberString[i] >= 48 && numberString[i] <= 57)
                    {
                        continue;
                    }
                    else if (numberString[i] >= 65 && numberString[i] <= 70)
                    {
                        continue;
                    }
                    else if (numberString[i] >= 97 && numberString[i] <= 102)
                    {
                        continue;
                    }
                    throw new ArgumentException($"Number is invalid");
                }
            }
        }
        #endregion
    }
}
