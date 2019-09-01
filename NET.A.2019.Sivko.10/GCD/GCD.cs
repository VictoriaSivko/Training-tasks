// <copyright file="GCD.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GCDTask
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The GCD class is used to find the largest common divisor of an arbitrary number of integers
    /// </summary>
    public class GCD
    {
        private delegate int StartAlgorithm(int[] array);

        private static StartAlgorithm start;

        /// <summary>
        /// The Euklid method finds the GCD of an arbitrary number of numbers by Euclidean algorithm
        /// </summary>
        /// <param name="arrayOfNumbers">Accepts an arbitrary number of integers</param>
        /// <returns>Greatest common divisor of numbers</returns>
        public static int Euklid(params int[] arrayOfNumbers)
        {
            ExceptionCheck(arrayOfNumbers);

            if (arrayOfNumbers.Length == 1)
            {
                return Math.Abs(arrayOfNumbers[0]);
            }

            start = EuclideanStart;
            int tempGCD = start(arrayOfNumbers);

            return tempGCD;
        }

        /// <summary>
        /// The Euklid method finds the GCD of an arbitrary number of numbers by Euclidean algorithm
        /// and returns milliseconds spent on finding the GCD
        /// </summary>
        /// <param name="millisecond">Milleseconds that were spent finding the GCD</param>
        /// <param name="arrayOfNumbers">Accepts an arbitrary number of integers</param>
        /// <returns>Greatest common divisor of numbers</returns>
        public static int Euklid(out long millisecond, params int[] arrayOfNumbers)
        {
            Stopwatch time = Stopwatch.StartNew();

            ExceptionCheck(arrayOfNumbers);

            if (arrayOfNumbers.Length == 1)
            {
                time.Stop();
                millisecond = time.ElapsedMilliseconds;
                return Math.Abs(arrayOfNumbers[0]);
            }

            start = EuclideanStart;
            int tempGCD = start(arrayOfNumbers);

            time.Stop();
            millisecond = time.ElapsedMilliseconds;
            return tempGCD;
        }

        private static int EuclideanStart(int[] arrayOfNumbers)
        {
            int tempGCD = EuclideanAlgorithm(Math.Abs(arrayOfNumbers[0]), Math.Abs(arrayOfNumbers[1]));

            for (int i = 2; i < arrayOfNumbers.Length; i++)
            {
                tempGCD = EuclideanAlgorithm(tempGCD, Math.Abs(arrayOfNumbers[i]));
                if (tempGCD == 1)
                {
                    break;
                }
            }

            return tempGCD;
        }

        private static int EuclideanAlgorithm(int a, int b)
        {
            if (a == b)
                return a;
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            while ((a != 0) && (b != 0))
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return Math.Max(a, b);
        }

        /// <summary>
        /// The Stein method finds the GCD of an arbitrary number of numbers by Stein's algorithm
        /// </summary>
        /// <param name="arrayOfNumbers">Accepts an arbitrary number of integers</param>
        /// <returns>Greatest common divisor of numbers</returns>
        public static int Stein(params int[] arrayOfNumbers)
        {
            ExceptionCheck(arrayOfNumbers);

            if (arrayOfNumbers.Length == 1)
            {
                return Math.Abs(arrayOfNumbers[0]);
            }

            start = SteinStart;
            int tempGCD = start(arrayOfNumbers);

            return tempGCD;
        }

        /// <summary>
        /// The Stein method finds the GCD of an arbitrary number of numbers by Stein's algorithm
        /// and returns milliseconds spent on finding the GCD
        /// </summary>
        /// <param name="millisecond">Milleseconds that were spent finding the GCD</param>
        /// <param name="arrayOfNumbers">Accepts an arbitrary number of integers</param>
        /// <returns>Greatest common divisor of numbers</returns>
        public static int Stein(out long millisecond, params int[] arrayOfNumbers)
        {
            Stopwatch time = Stopwatch.StartNew();

            ExceptionCheck(arrayOfNumbers);

            if (arrayOfNumbers.Length == 1)
            {
                time.Stop();
                millisecond = time.ElapsedMilliseconds;
                return Math.Abs(arrayOfNumbers[0]);
            }

            start = SteinStart;
            int tempGCD = start(arrayOfNumbers);

            time.Stop();
            millisecond = time.ElapsedMilliseconds;
            return tempGCD;
        }

        private static int SteinStart(int[] arrayOfNumbers)
        {
            int tempGCD = SteinAlgorithm(Math.Abs(arrayOfNumbers[0]), Math.Abs(arrayOfNumbers[1]));

            for (int i = 2; i < arrayOfNumbers.Length; i++)
            {
                tempGCD = SteinAlgorithm(tempGCD, Math.Abs(arrayOfNumbers[i]));
                if (tempGCD == 1)
                {
                    break;
                }
            }

            return tempGCD;
        }

        private static int SteinAlgorithm(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            bool aIsEven = (a & 1u) == 0;
            bool bIsEven = (b & 1u) == 0;

            // If both values are even numbers
            // then we know that the value two is a common divisor
            if (aIsEven && bIsEven)
            {
                return SteinAlgorithm(a >> 1, b >> 1) << 1;
            }

            // If at least one number even it can be divided into two
            // But the two are not a common divisor
            else if (aIsEven && !bIsEven)
            {
                return SteinAlgorithm(a >> 1, b);
            }
            else if (bIsEven)
            {
                return SteinAlgorithm(a, b >> 1);
            }

            // Otherwise, according to Euclid's algorithm
            // we subtract the numbers
            else if (a > b)
            {
                return SteinAlgorithm((a - b) >> 1, b);
            }
            else
            {
                return SteinAlgorithm(a, (b - a) >> 1);
            }
        }

        private static void ExceptionCheck(int[] arrayOfNumbers)
        {
            if (arrayOfNumbers.Length == 0)
            {
                throw new NullReferenceException("No parameters were sent to the method for finding the GCD");
            }

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                if (arrayOfNumbers[i] == int.MinValue)
                {
                    throw new IndexOutOfRangeException("int.MinValue is beyond the acceptable parameter value");
                }
            }
        }
    }
}
