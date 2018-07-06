using System;
using System.Diagnostics;

namespace GCD
{
    /// <summary>
    /// Finder greatest common divisor in array of numbers
    /// </summary>
    public class GCD
    {
        #region public API
        /// <summary>
        /// Starts the search GCD(Euclidean algorithm)
        /// </summary>
        /// <param name="numbers"> Used numbers </param>
        /// <returns> GCD </returns>
        public static int GetGCD(params int[] numbers)
        {
            IsValid(numbers);
            int gcd = GCDSorter(numbers);
            return gcd;
        }
        
        /// <summary>
        /// Starts the search GCD(Euclidean algorithm)
        /// </summary>
        /// <param name="numbers"> Used numbers </param>
        /// <returns> GCD and work time </returns>
        public static (int, TimeSpan) GetGCDWidthTime(params int[] numbers)
        {
            Stopwatch stopTime = Stopwatch.StartNew();
            stopTime.Start();
            IsValid(numbers);
            int gcd = GCDSorter(numbers);
            stopTime.Stop();
            TimeSpan resultTime = stopTime.Elapsed;
            return (gcd, resultTime);
        }

        /// <summary>
        /// Starts the search GCD for 2 numbers(Euclidean algorithm)
        /// </summary>
        /// <param name="firstNumber"> First number </param>
        /// <param name="secondNumber"></param>
        /// <returns> GCD </returns>
        public static int GetGCD(int firstNumber, int secondNumber)
        {
            if (value1 < 0)
            {
                value1 *= -1;
            }

            if (value2 < 0)
            {
                value2 *= -1;
            }
            int answer = -1;
            if (value1 > value2)
            {
                answer = GCDCalculator(value1, value2);
            }
            else if (value2 > value1)
            {
                answer = GCDCalculator(value2, value1);
            }
            else if (value1 == value2)
            {
                answer = value1;
            }

            return answer;
        }

        /// <summary>
        /// Starts the search GCD for 3 numbers(Euclidean algorithm)
        /// </summary>
        /// <param name="firstNumber"> First number</param>
        /// <param name="secondNumber"> Second number</param>
        /// <param name="thirdNumber"> Thrid number </param>
        /// <returns></returns>
        public static int GetGCD(int firstNumber, int secondNumber, int thirdNumber)
        {
            int gcd = GetGCDTwoNumbers(firstNumber, secondNumber);
            gcd = GetGCDTwoNumbers(gcd, thirdNumber);
            return gcd;
        }

        /// <summary>
        /// Starts the search GCD(Stein's algorithm)
        /// </summary>
        /// <param name="numbers"> Used numbers </param>
        /// <returns> GCD </returns>
        public static int GetSteinGCD(params int[] numbers)
        {
            IsValid(numbers);
            int gcd = SteinGCD(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                gcd = SteinGCD(gcd, numbers[i]);
                if (gcd == 1)
                {
                    return gcd;
                }
            }

            return gcd;
        }
        #endregion
        #region private API
        private static int GCDSorter(int[] numbers)
        {
            int gcd = GetGCDTwoNumbers(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                gcd = GetGCDTwoNumbers(gcd, numbers[i]);
                if (gcd == 1)
                {
                    return gcd;
                }
            }

            return gcd;
        }

        /// <summary>
        ///  GCD search algorithm(Euclidean)
        /// </summary>
        /// <param name="value1"> First number </param>
        /// <param name="value2"> Second number </param>
        /// <returns> GCD </returns>
        private static int GCDCalculator(int value1, int value2)
        {
            if (value2 != 0)
            {
                int temp = value1 / value2;
                if (temp >= 1)
                {
                    value1 = value1 - (value2 * temp);
                    value1 = GCDCalculator(value2, value1);
                }

                return value1;
            }
            else
            {
                return value1;
            }
        }

        /// <summary>
        ///  GCD search algorithm(Stein's algorithm)
        /// </summary>
        /// <param name="value1"> First number </param>
        /// <param name="value2"> Second number </param>
        /// <returns> GCD </returns>
        private static int SteinGCD(int value1, int value2)
        {
            if (value1 == value2)
            {
                return value1;
            }

            if (value1 == 0)
            {
                return value2;
            }

            if (value2 == 0)
            {
                return value1;
            }

            if ((~value1 & 1) != 0)
            {
                if ((value2 & 1) != 0)
                {
                    return SteinGCD(value1 >> 1, value2);
                }
                else
                {
                    return SteinGCD(value1 >> 1, value2 >> 1) << 1;
                }
            }

            if ((~value2 & 1) != 0)
            {
                return SteinGCD(value1, value2 >> 1);
            }

            if (value1 > value2)
            {
                return SteinGCD((value1 - value2) >> 1, value2);
            }

            return SteinGCD((value2 - value1) >> 1, value1);
        }

        /// <summary>
        /// Checked if array is valid(if number[i] less 0, multiply by -1, numbers.Length !=0 !=1 )
        /// </summary>
        /// <param name="numbers"> Used numbers </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the number less than  0 or length of array = 1 or = 0
        /// </exception>
        private static void IsValid(int[] numbers)
        {
            if (numbers.Length == 0 || numbers.Length == 1)
            {
                throw new ArgumentException($"Enter at least 2 numbers");
            }
        }
        #endregion
    }
}
