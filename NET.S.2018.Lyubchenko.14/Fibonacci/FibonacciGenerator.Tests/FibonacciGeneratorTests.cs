using System;
using System.Collections.Generic;
using System.Numerics;
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
            List<BigInteger> actual = new List<BigInteger>();
            foreach (BigInteger el in FibonacciGenerator.GeneratorFibonacci(3))
            {
                actual.Add(el);
            }

            List<BigInteger> expected = new List<BigInteger>() { new BigInteger(1), new BigInteger(1), new BigInteger(2) };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GeneratorFibonacci_7_DoneArray()
        {
            List<BigInteger> actual = new List<BigInteger>();
            foreach (BigInteger el in FibonacciGenerator.GeneratorFibonacci(7))
            {
                actual.Add(el);
            }

            List<BigInteger> expected = new List<BigInteger>() { new BigInteger(1), new BigInteger(1),
                new BigInteger(2), new BigInteger(3), new BigInteger(5), new BigInteger(8), new BigInteger(13) };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GeneratorFibonacci_9_DoneArray()
        {
            List<BigInteger> actual = new List<BigInteger>();
            foreach (BigInteger el in FibonacciGenerator.GeneratorFibonacci(9))
            {
                actual.Add(el);
            }

            List<BigInteger> expected = new List<BigInteger>() { new BigInteger(1), new BigInteger(1), new BigInteger(2), new BigInteger(3),
                new BigInteger(5), new BigInteger(8),new BigInteger(13), new BigInteger(21), new BigInteger(34) };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GeneratorFibonacci_Exception()
            => FibonacciGenerator.GeneratorFibonacci(0);
    }
}