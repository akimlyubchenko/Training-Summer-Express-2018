using System;
using FibonacciGenereator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fibonacci.Tests
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void GeneratorFibonacci_3_DoneArray()
        {
            int size = 3;
            int[] expected = new int[] { 1, 1, 2 };

            int[] actual = FibonacciGenerator.GeneratorFibonacci(size);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GeneratorFibonacci_7_DoneArray()
        {
            int size = 7;
            int[] expected = new int[] { 1, 1, 2, 3, 5, 8, 13 };

            int[] actual = FibonacciGenerator.GeneratorFibonacci(size);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GeneratorFibonacci_11_DoneArray()
        {
            int size = 11;
            int[] expected = new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

            int[] actual = FibonacciGenerator.GeneratorFibonacci(size);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeneratorFibonacci_Exception()
            => FibonacciGenerator.GeneratorFibonacci(0);
    }
}