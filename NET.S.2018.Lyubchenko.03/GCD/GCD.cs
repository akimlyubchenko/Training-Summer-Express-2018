using System;
using System.Diagnostics;

namespace GCD
{
    /// <summary>
    /// Finder greatest common divisor in array of numbers
    /// </summary>
    public class GCD
    {
        #region Euclidean algorithm
        /// <summary>
        /// Starts the search GCD(Euclidean algorithm)
        /// </summary>
        /// <param name="numbers"> Used numbers </param>
        /// <returns> GCD </returns>
        public static int GetGCD(params int[] numbers)
        {
            IsValid(numbers);
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
        /// Particular cases and order of numbers
        /// </summary>
        /// <param name="value1"> First number </param>
        /// <param name="value2"> Second number </param>
        /// <returns> GCD </returns>
        private static int GetGCDTwoNumbers(int value1, int value2)
        {
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
        #endregion
        #region Stein's algorithm
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
        #endregion
        #region Timing
        /// <summary>
        /// Time of Euclidean algorithm execution
        /// </summary>
        /// <returns> Time </returns>
        public static string TimingEuclidean()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            GetGCD(2226, 4256, 44444444, 444444444, 44444444, 666666666, 888888, 666666, 4222, 1246, 846466);
            stopWatch.Stop();
            TimeSpan timespan = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}.{4:00}",
                timespan.Hours, timespan.Minutes, timespan.Seconds,
                timespan.Milliseconds ,timespan.Ticks);
            return elapsedTime;
        }

        /// <summary>
        /// Time of Stein's algorithm execution
        /// </summary>
        /// <returns> Time </returns>
        public static string TimingStein()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            GetSteinGCD(15, 33, 9, 345, 345, 335345356, 123123, 5675858, 21324235, 23465);
            stopWatch.Stop();
            TimeSpan timespan = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}.{4:00}",
                timespan.Hours, timespan.Minutes, timespan.Seconds,
                timespan.Milliseconds, timespan.Ticks);
            return elapsedTime;
        }
        #endregion

        /// <summary>
        /// Checked if array is valid(number[i] must be > 0 , numbers.Length !=0 !=1 )
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

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    throw new ArgumentException($"Value {numbers[i]} mustn't be negative");
                }
            }
        }
    }
}
