﻿using System;

namespace NET.A._2019.Sivko._02
{
    public class Root
    {
        /// <summary>
        /// The FindNthRoot method finds the root of the number by Newton's iterative formula
        /// </summary>
        /// <param name="number">Original number</param>
        /// <param name="root">Root</param>
        /// <param name="eps">EPS</param>
        /// <returns>The root of a number with given EPS accuracy</returns>
        public static double FindNthRoot(double number, double root, double eps)
        {
            if (eps < 0)
                throw new IndexOutOfRangeException("Wrong EPS");

            double x0 = number/root;
            double x1 = (1 / root) * ((root - 1) * x0 + number / Math.Pow(x0, (int)root - 1));


            while(Math.Abs(x1-x0) >= eps)
            {
                x0 = x1;
                x1 = (1 / root) * ((root - 1) * x0 + number / Math.Pow(x0, (int)root - 1));
            }

            return x1;
        }
    }
}
