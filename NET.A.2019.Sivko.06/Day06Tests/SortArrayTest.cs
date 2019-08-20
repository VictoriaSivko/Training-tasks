using NUnit.Framework;
using NET.A._2019.Sivko._06;
using System;

namespace Day06Tests
{
    [TestFixture]
    public class SortArrayTest
    {
        [Test]
        public static void SomeOfArraysIsNullTest()
        {
            int[][] array = new int[5][];
            array[0] = new int[] { 4, 2, 5, 1, 5 };
            array[1] = new int[] { 3, 1, 105, 3 };
            array[3] = new int[] { 92, 0, 1 };

            int[][] excpected = new int[5][];
            excpected[0] = new int[] { 4, 2, 5, 1, 5 };
            excpected[1] = new int[] { 92, 0, 1 };
            excpected[2] = new int[] { 3, 1, 105, 3 };

            SortArray.AscendingSortByMaxElement(array);

            CollectionAssert.AreEqual(array, excpected);
        }

        [Test]
        public static void NullExceptionTest()
        {
            int[][] array = new int[0][];
            var ex = Assert.Catch<Exception>(() => SortArray.AscendingSortByMaxElement(array));
            StringAssert.Contains("Received a null array", ex.Message);
        }

        [Test]
        public static void OneArrayTest()
        {
            int[][] array = new int[1][];
            array[0] = new int[] { 4, 2, 5, 1, 5 };

            int[][] excpected = new int[1][];
            excpected[0] = new int[] { 4, 2, 5, 1, 5 };

            SortArray.AscendingSortByMaxElement(array);

            CollectionAssert.AreEqual(array, excpected);
        }

        [Test]
        public static void AscendingSortByMaxElementTest()
        {
            int[][] array = new int[5][];
            array[0] = new int[] { 4, 2, 5, 1, 5 };
            array[1] = new int[] { 3, 1, int.MaxValue, 3 };
            array[2] = new int[] { 0, 6, -34, 0 };
            array[3] = new int[] { 92, 0, 1 };
            array[4] = new int[] { 15, 5, int.MinValue, -1, 9 };

            int[][] excpected = new int[5][];
            excpected[0] = new int[] { 4, 2, 5, 1, 5 };
            excpected[1] = new int[] { 0, 6, -34, 0 };
            excpected[2] = new int[] { 15, 5, int.MinValue, -1, 9 };
            excpected[3] = new int[] { 92, 0, 1 };
            excpected[4] = new int[] { 3, 1, int.MaxValue, 3 };

            SortArray.AscendingSortByMaxElement(array);

            CollectionAssert.AreEqual(array, excpected);
        }

        [Test]
        public static void DecreasingSortByMaxElementTest()
        {
            int[][] array = new int[5][];
            array[0] = new int[] { 4, 2, 5, 1, 5 };
            array[1] = new int[] { 3, 1, int.MaxValue, 3 };
            array[2] = new int[] { 0, 6, -34, 0 };
            array[3] = new int[] { 92, 0, 1 };
            array[4] = new int[] { 15, 5, int.MinValue, -1, 9 };

            int[][] excpected = new int[5][];
            excpected[0] = new int[] { 3, 1, int.MaxValue, 3 };
            excpected[1] = new int[] { 92, 0, 1 };
            excpected[2] = new int[] { 15, 5, int.MinValue, -1, 9 };
            excpected[3] = new int[] { 0, 6, -34, 0 };
            excpected[4] = new int[] { 4, 2, 5, 1, 5 };

            SortArray.DecreasingSortByMaxElement(array);

            CollectionAssert.AreEqual(array, excpected);
        }

        [Test]
        public static void AscendingSortByMinElementTest()
        {
            int[][] array = new int[5][];
            array[0] = new int[] { 4, 2, 5, 1, 5 };
            array[1] = new int[] { 3, 1, int.MaxValue, 3 };
            array[2] = new int[] { 0, 6, -34, 0 };
            array[3] = new int[] { 92, 0, 1 };
            array[4] = new int[] { 15, 5, int.MinValue, -1, 9 };

            int[][] excpected = new int[5][];
            excpected[0] = new int[] { 15, 5, int.MinValue, -1, 9 };
            excpected[1] = new int[] { 0, 6, -34, 0 };
            excpected[2] = new int[] { 92, 0, 1 };
            excpected[3] = new int[] { 4, 2, 5, 1, 5 };
            excpected[4] = new int[] { 3, 1, int.MaxValue, 3 };

            SortArray.AscendingSortByMinElement(array);

            CollectionAssert.AreEqual(array, excpected);
        }

        [Test]
        public static void DecreasingSortByMinElementTest()
        {
            int[][] array = new int[5][];
            array[0] = new int[] { 4, 2, 5, 1, 5 };
            array[1] = new int[] { 3, 2, int.MaxValue, 3 };
            array[2] = new int[] { 0, 6, -34, 0 };
            array[3] = new int[] { 92, 0, 1 };
            array[4] = new int[] { 15, 5, int.MinValue, -1, 9 };

            int[][] excpected = new int[5][];
            excpected[0] = new int[] { 3, 2, int.MaxValue, 3 };
            excpected[1] = new int[] { 4, 2, 5, 1, 5 };
            excpected[2] = new int[] { 92, 0, 1 };
            excpected[3] = new int[] { 0, 6, -34, 0 };
            excpected[4] = new int[] { 15, 5, int.MinValue, -1, 9 };

            SortArray.DecreasingSortByMinElement(array);

            CollectionAssert.AreEqual(array, excpected);
        }

        [Test]
        public static void AscendingSortBySumOfElementsTest()
        {
            int[][] array = new int[5][];
            array[0] = new int[] { 4, 2, 5, 1, 5 };//17
            array[1] = new int[] { 3, 1, int.MaxValue, 3 };//max
            array[2] = new int[] { 0, 6, -34, 0 };//-28
            array[3] = new int[] { 92, 0, 1 };//93
            array[4] = new int[] { 15, 5, int.MinValue, -1, 9 };//min

            int[][] excpected = new int[5][];
            excpected[0] = new int[] { 15, 5, int.MinValue, -1, 9 };
            excpected[1] = new int[] { 0, 6, -34, 0 };
            excpected[2] = new int[] { 4, 2, 5, 1, 5 };
            excpected[3] = new int[] { 92, 0, 1 };
            excpected[4] = new int[] { 3, 1, int.MaxValue, 3 };

            SortArray.AscendingSortBySumOfElements(array);

            CollectionAssert.AreEqual(array, excpected);
        }

        [Test]
        public static void DecreasingSortBySumOfElementsTest()
        {
            int[][] array = new int[5][];
            array[0] = new int[] { 4, 2, 5, 1, 5 };//17
            array[1] = new int[] { 3, 1, int.MaxValue, 3 };//max
            array[2] = new int[] { 0, 6, -34, 0 };//-28
            array[3] = new int[] { 92, 0, 1 };//93
            array[4] = new int[] { 15, 5, int.MinValue, -1, 9 };//min

            int[][] excpected = new int[5][];
            excpected[0] = new int[] { 3, 1, int.MaxValue, 3 };
            excpected[1] = new int[] { 92, 0, 1 };
            excpected[2] = new int[] { 4, 2, 5, 1, 5 };
            excpected[3] = new int[] { 0, 6, -34, 0 };
            excpected[4] = new int[] { 15, 5, int.MinValue, -1, 9 };

            SortArray.DecreasingSortBySumOfElements(array);

            CollectionAssert.AreEqual(array, excpected);
        }
    }
}
