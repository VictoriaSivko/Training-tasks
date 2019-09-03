using System;

namespace LibDay11
{
    /// <summary>
    /// Fibonacci class to generate a sequence of Fibonacci numbers.
    /// </summary>
    public class Fibonacci
    {
        /// <summary>
        /// Generates the first n numbers of the Fibonacci sequence.
        /// </summary>
        /// <param name="n">Number of sequence numbers.</param>
        /// <returns>Fibonacci number sequence</returns>
        public static long[] FibonacciNumbers(int n)
        {
            if (n < 1)
                throw new Exception("Cannot create a negative sequence of Fibonacci numbers");

            long[] fibArray = new long[n];
            for (int i = 1; i < n; i++)
                fibArray[i] = GenerateFibonacciNumbers(i);

            return fibArray; 
        }

        private static long GenerateFibonacciNumbers(int n)
        {
            if (n < 3)
                return 1;
            else
                return GenerateFibonacciNumbers(n - 1) + GenerateFibonacciNumbers(n - 2);
        }
    }
}
