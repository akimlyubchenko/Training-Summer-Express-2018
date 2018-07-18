using System;

namespace ToDecimal
{
    /// <summary>
    /// Converter number from any notation more 1 and less 17, to decimal number
    /// </summary>
    public static class ToDecimal
    {
        private const string ALPHABET = "0123456789ABCDEFGHIKLMNOPQRSTVXYZ";

        #region public API        
        /// <summary>
        /// Converter number from any notation more 1 and less 17, to decimal number
        /// </summary>
        /// <param name="numberString"> Entered number in string </param>
        /// <param name="notation"> The notation </param>
        /// <returns> Integer decimal number</returns>
        public static int ToDecimalConverter(string numberString, int notation)
        {
            Validator(numberString, notation);
            numberString = numberString.ToUpper();
            string usedAlphabet = ALPHABET.Substring(0, notation);
            return StringIntConvert(numberString, usedAlphabet, notation);
        }
        #endregion

        #region private methods        
        /// <summary>
        /// Works with a ready array of numbers
        /// </summary>
        /// <param name="numbers"> The ready array </param>
        /// <param name="notation"> The notation </param>
        /// <returns> A ready number </returns>
        private static int DoneNumber(ref int power, int numberString, int notation)
        {
            int doneNumber = 0;
            doneNumber += numberString * power;
            power /= notation;
            return doneNumber;
        }

        /// <summary>
        /// From string to int converter
        /// </summary>
        /// <param name="numberString"> Elementary string </param>
        /// <param name="notation"> The notation </param>
        /// <returns> Int array </returns>
        private static int StringIntConvert(string numberString, string usedAlphabet, int notation)
        {
            if (usedAlphabet.Length > 10)
            {
                return StringIntConvertMoreDecimal(numberString, usedAlphabet, notation); ;
            }
            else
            {
                int doneNumber = 0;
                int power = (int)Math.Pow(notation, numberString.Length - 1);
                for (int i = 0; i < numberString.Length; i++)
                {
                    checked
                    {
                        doneNumber += DoneNumber(ref power, numberString[i] - 48, notation);
                    }

                }

                return doneNumber;
            }
        }

        /// <summary>
        /// From string to int converter width notation more as 10
        /// </summary>
        /// <param name="numberString"> Elementary string </param>
        /// <returns> Int array </returns>
        private static int StringIntConvertMoreDecimal(string numberString, string usedAlphabet, int notation)
        {
            int doneNumber = 0;
            int power = (int)Math.Pow(notation, numberString.Length - 1);
            for (int i = 0; i < numberString.Length; i++)
            {
                if (numberString[i] < 58)
                {
                    checked
                    {
                        doneNumber += DoneNumber(ref power, numberString[i] - 48, notation);
                    }
                }
                else
                {
                    checked
                    {
                        doneNumber += DoneNumber(ref power, usedAlphabet.IndexOf(numberString[i]), notation);
                    }
                }
            }

            return doneNumber;
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
        private static void Validator(string numberString, int notation)
        {
            if (notation < 2 || notation > 16)
            {
                throw new ArgumentException($"{nameof(notation)} isn't valid");
            }

            if (string.IsNullOrEmpty(numberString))
            {
                throw new ArgumentException($"{nameof(numberString)} must be completed");
            }

            numberString = numberString.ToUpper();
            string usedAlphabet = ALPHABET.Substring(0, notation);
            int count = -1;
            for (int i = 0; i < numberString.Length; i++)
            {
                for (int j = 0; j < usedAlphabet.Length; j++)
                {
                    if (numberString[i] == usedAlphabet[j])
                    {
                        count++;
                        break;
                    }
                }

                if (count != i)
                {
                    throw new ArgumentException($"number {numberString[i]} can't contain in the {notation} number system");
                }
            }

        }
        #endregion
    }
}
