namespace NET.A._2019.Sivko._06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The SortArray class is used to sort a jagged array by bubble sorting
    /// </summary>
    public class SortArray
    {
        public delegate int Comparator(int[] x, int[] y);

        /// <summary>
        /// Bubble sorting in ascending order.
        /// </summary>
        /// <param name="array">The source jagged array.</param>
        /// <param name="compare">The parameter by which the jagged array will be sorted.</param>
        public static void BubbleSortAscending(int[][] array, IComparer<int[]> compare)
        {
            CheckingForNullArray(array);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0) - 1 - i; j++)
                {
                    if (compare.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Transfers control to a method that works with the interface.
        /// </summary>
        /// <param name="array">The source jagged array.</param>
        /// <param name="compare">The parameter by which the jagged array will be sorted.</param>
        public static void BubbleSortAscending(int[][] array, Comparator compare)
        {
            Type type = compare.Method.DeclaringType;
            BubbleSortAscending(array, Activator.CreateInstance(type) as IComparer<int[]>);
        }

        /// <summary>
        /// Bubble sorting in decreasing order.
        /// </summary>
        /// <param name="array">The source jagged array.</param>
        /// <param name="compare">The parameter by which the jagged array will be sorted.</param>
        public static void BubbleSortDecreasing(int[][] array, Comparator compare)
        {
            CheckingForNullArray(array);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0) - 1 - i; j++)
                {
                    if (compare(array[j], array[j + 1]) < 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Transfers control to the method that works with the delegate.
        /// </summary>
        /// <param name="array">The source jagged array.</param>
        /// <param name="compare">The parameter by which the jagged array will be sorted.</param>
        public static void BubbleSortDecreasing(int[][] array, IComparer<int[]> compare)
        {
            BubbleSortDecreasing(array, compare.Compare);
        }

        /// <summary>
        /// Helper method swaps arrays of jagged array
        /// </summary>
        private static void Swap(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }

        /// <summary>
        /// The CheckingForNullArray method checks whether the array is null
        /// </summary>
        private static void CheckingForNullArray(int[][] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException("Received a null array");
            }
        }
    }

    public class Max : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null || x.Length == 0)
                return 1;

            if (y == null || y.Length == 0)
                return -1;

            if (x.Max() > y.Max())
                return 1;
            else if (x.Max() < y.Max())
                return -1;
            else
                return 0;
        }

        public static int CompareByMaxElement(int[] x, int[] y)
        {
            return x.Max().CompareTo(y.Max());
        }
    }

    public class Min : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null || x.Length == 0)
                return 1;

            if (y == null || y.Length == 0)
                return -1;

            if (x.Min() > y.Min())
                return 1;
            else if (x.Min() < y.Min())
                return -1;
            else
                return 0;
        }

        public static int CompareByMinElement(int[] x, int[] y)
        {
            return x.Min().CompareTo(y.Min());
        }
    }

    public class Sum : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null || x.Length == 0)
                return 1;

            if (y == null || y.Length == 0)
                return -1;

            if (Summ(x) > Summ(y))
                return 1;
            else if (Summ(x) < Summ(y))
                return -1;
            else
                return 0;
        }

        public static int CompareBySum(int[] x, int[] y)
        {

            return Summ(x).CompareTo(Summ(y));
        }

        private static long Summ(int[] temp)
        {
            if (temp == null)
                return long.MaxValue;

            long sum = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                sum += temp[i];
            }

            return sum;
        }
    }
}
