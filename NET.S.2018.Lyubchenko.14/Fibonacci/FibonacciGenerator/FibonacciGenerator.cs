using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciGenereator
{
    /// <summary>
    /// Generator Fibonacci numbers
    /// </summary>
    public static class FibonacciGenerator
    {
        /// <summary>
        /// Generator Fibonacci numbers
        /// </summary>
        /// <param name="size">The size of array</param>
        /// <returns>Array width Fibonacci numbers</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static IEnumerable<BigInteger> GeneratorFibonacci(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException($"Write size > 0");
            }

            return GeneratorFibonacciWithoutValidation(size);
        }

        private static IEnumerable<BigInteger> GeneratorFibonacciWithoutValidation(int size)
        {
            BigInteger value1 = 1, value2 = 0, temp = 0;
            for (int i = 0; i < size; i++)
            {
                yield return value1;
                temp = value1;
                value1 += value2;
                value2 = temp;
            }
        }
    }
}