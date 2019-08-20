using System;

namespace NET.A._2019.Sivko._06
{
    /// <summary>
    /// The SortArray class is used to sort a jagged array by bubble sorting
    /// </summary>
    public class SortArray
    {
        /// <summary>
        /// The AscendingSortByMaxElement method is used to sort in ascending 
        /// order of maximum elements of matrix rows
        /// </summary>
        /// <param name="array">The source jagged array</param>
        public static void AscendingSortByMaxElement(int[][] array)
        {
            CheckingForNullArray(array);

            BubbleSortAscending(array, 0);
        }

        /// <summary>
        /// The DecreasingSortByMaxElement method is used to sort in descending 
        /// order of maximum elements of matrix rows
        /// </summary>
        /// <param name="array">The source jagged array</param>
        public static void DecreasingSortByMaxElement(int[][] array)
        {
            CheckingForNullArray(array);

            BubbleSortDecreasing(array, 0);
        }

        /// <summary>
        /// The AscendingSortByMinElement method is used to sort in ascending 
        /// order of minimum elements of matrix rows
        /// </summary>
        /// <param name="array">The source jagged array</param>
        public static void AscendingSortByMinElement(int[][] array)
        {
            CheckingForNullArray(array);

            BubbleSortAscending(array, 1);
        }

        /// <summary>
        /// The DecreasingSortByMinElement method is used to sort in descending 
        /// order of minimum elements of matrix rows
        /// </summary>
        /// <param name="array">The source jagged array</param>
        public static void DecreasingSortByMinElement(int[][] array)
        {
            CheckingForNullArray(array);

            BubbleSortDecreasing(array, 1);
        }

        /// <summary>
        /// The AscendingSortBySumOfElements method is used to sort in ascending 
        /// order of sums of matrix row elements
        /// </summary>
        /// <param name="array">The source jagged array</param>
        public static void AscendingSortBySumOfElements(int[][] array)
        {
            CheckingForNullArray(array);

            BubbleSortAscending(array, 2);
        }

        /// <summary>
        /// The DecreasingSortBySumOfElements method is used to sort in descending 
        /// order of sums of matrix row elements
        /// </summary>
        /// <param name="array">The source jagged array</param>
        public static void DecreasingSortBySumOfElements(int[][] array)
        {
            CheckingForNullArray(array);

            BubbleSortDecreasing(array, 2);
        }

        /// <summary>
        /// Finds the largest element in the array
        /// </summary>
        private static int MaxElement(int[] temp)
        {
            if (temp == null)
                return int.MaxValue;

            int max = temp[0];

            for (int i = 1; i < temp.Length; i++)
            {
                if (max < temp[i])
                    max = temp[i];
            }

            return max;
        }

        /// <summary>
        /// Finds the smallest element of an array
        /// </summary>
        private static int MinElement(int[] temp)
        {
            if (temp == null)
                return int.MaxValue;

            int min = temp[0];

            for (int i = 1; i < temp.Length; i++)
            {
                if (min > temp[i])
                    min = temp[i];
            }

            return min;
        }

        /// <summary>
        /// Finds the sum of array elements
        /// </summary>
        private static long Sum(int[] temp)
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

        /// <summary>
        /// Bubble sorting in ascending order
        /// </summary>
        /// <param name="array">The source jagged array</param>
        /// <param name="selectSort">The parameter by which the jagged array will be sorted</param>
        private static void BubbleSortAscending(int[][] array, int selectSort)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0) - 1 - i; j++)
                {
                    //By max element
                    if (selectSort == 0)
                    {
                        if (MaxElement(array[j]) > MaxElement(array[j + 1]))
                            Swap(ref array[j], ref array[j + 1]);
                    }
                    //By min element
                    else if (selectSort == 1)
                    {
                        if (MinElement(array[j]) > MinElement(array[j + 1]))
                            Swap(ref array[j], ref array[j + 1]);
                    }
                    //By sum of elements
                    else
                    {
                        if (Sum(array[j]) > Sum(array[j + 1]))
                            Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Bubble sorting in decreasing order
        /// </summary>
        /// <param name="array">The source jagged array</param>
        /// <param name="selectSort">The parameter by which the jagged array will be sorted</param>
        private static void BubbleSortDecreasing(int[][] array, int selectSort)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0) - 1 - i; j++)
                {
                    //By max element
                    if (selectSort == 0)
                    {
                        if (MaxElement(array[j]) < MaxElement(array[j + 1]))
                            Swap(ref array[j], ref array[j + 1]);
                    }
                    //By min element
                    else if (selectSort == 1)
                    {
                        if (MinElement(array[j]) < MinElement(array[j + 1]))
                            Swap(ref array[j], ref array[j + 1]);
                    }
                    //By sum of elements
                    else
                    {
                        if (Sum(array[j]) < Sum(array[j + 1]))
                            Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
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
                throw new ArgumentNullException("Received a null array");
        }
    }
}
