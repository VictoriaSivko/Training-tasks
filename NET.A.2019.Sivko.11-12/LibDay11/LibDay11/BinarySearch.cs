using System;
using System.Collections.Generic;

namespace LibDay11
{
    /// <summary>
    /// Implements Binary search
    /// </summary>
    public static class BinarySearch
    {
        /// <summary>
        /// Searches for the specified element in the array using binary search.
        /// </summary>
        /// <typeparam name="T">Type of data to be searched.</typeparam>
        /// <param name="array">Data array.</param>
        /// <param name="value">The desired value.</param>
        /// <returns>Index of the sought value or -1 if no match is found.</returns>
        public static int GenericBinarySearch<T>(T[] array, T value)
        {
            if (array == null)
            {
                throw new ArgumentException("array");
            }

            if (value == null)
            {
                throw new ArgumentException("value");
            }

            int left = 0;
            int right = array.Length - 1;
            int middle, result;

            if (left == right)
            {
                return left;
            }

            IComparer<T> comparer = Comparer<T>.Default;

            Array.Sort(array);

            while (left <= right)
            {
                if (right - left == 1)
                {
                    if (comparer.Compare(array[left], value) == 0)
                        return left;
                    if (comparer.Compare(array[right], value) == 0)
                        return right;
                    return -1;
                }
                else
                {
                    middle = left + (right - left) / 2;
                    result = comparer.Compare(array[middle], value);

                    if (result == 0)
                    {
                        return middle;
                    }
                    else if (result < 0)
                    {
                        left = middle;
                    }
                    else
                    {
                        right = middle;
                    }
                }
            }

            return -1;
        }
    }
}
