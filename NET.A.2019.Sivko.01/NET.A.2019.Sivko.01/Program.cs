using System;
using Sortings;

namespace NET.A._2019.Sivko._01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 3, 0, 1, 8, 7, 2, 5, 4, 9, 6 };
            int[] b = { 3, 0, 1, 8, 7, 2, 5, 4, 9, 6 };
            Console.WriteLine("Unsorted array:");
            View(a);

            Sorting.QuickSort(a, 0, a.Length - 1);
            b = Sorting.MergeSort(b);

            Console.WriteLine("QuickSort:");
            View(a);
            Console.WriteLine("MergeSort:");
            View(b);
            Console.ReadKey();
        }

        public static void View(int[] a)
        {
            for(int i = 0; i<a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
