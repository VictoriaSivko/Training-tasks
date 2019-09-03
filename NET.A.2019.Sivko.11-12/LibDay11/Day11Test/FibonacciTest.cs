using System;
using NUnit.Framework;
using LibDay11;

namespace Day11Test
{
    [TestFixture]
    public class FibonacciTest
    {
        [TestCase(1, ExpectedResult = new long[] { 0 })]
        [TestCase(2, ExpectedResult = new long[] { 0, 1 })]
        [TestCase(22, ExpectedResult = new long[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946 })]
        public long[] SequenceOfFibonacci(int n)
        {
            return Fibonacci.FibonacciNumbers(n);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void SequenceOfFibonacciExceptions(int n)
        {
            var ex = Assert.Catch<Exception>(() => Fibonacci.FibonacciNumbers(n));
            StringAssert.Contains("Cannot create a negative sequence", ex.Message);
        }
    }
}
