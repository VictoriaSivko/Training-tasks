using Sortings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingSortings
{
    [TestClass]
    public class TestSorts
    {
        [TestMethod]
        public void QuickSortTest()
        {
            //source data
            int[] actual = { 3, 0, 1, 8, 7, 2, 5, 4, 9, 6 };
            int[] expected = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Sorting.QuickSort(actual, 0, actual.Length - 1);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            //source data
            int[] original = { 3, 0, 1, 8, 7, 2, 5, 4, 9, 6 };
            int[] expected = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] actual = Sorting.MergeSort(original);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
