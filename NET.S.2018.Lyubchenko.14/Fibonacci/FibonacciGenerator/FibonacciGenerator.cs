using System;

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
        public static int[] GeneratorFibonacci(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException($"Write size > 0");
            }

            int[] fib = new int[size];
            int value = 1;
            fib[0] = value;
            for (int i = 1; i < size; i++)
            {
                fib[i] = value;
                value += fib[i - 1];
            }
            return fib;
        }
    }
}