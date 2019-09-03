using System;
using NUnit.Framework;
using LibDay11;

namespace Day11Test
{
    [TestFixture]
    public class BinarySearchTest
    {
        [TestCase(new int[] { 3, 64, 2, int.MaxValue, 54, 16}, int.MaxValue, ExpectedResult = 5)]
        [TestCase(new int[] { 3, 64, 2, int.MinValue, 54, 16 }, int.MinValue, ExpectedResult = 0)]
        [TestCase(new int[] { 16, 64, 2, 15, 54, 3 }, 16, ExpectedResult = 3)]
        [TestCase(new int[] { 3, 64, 2, 15, 54 }, 2, ExpectedResult = 0)]
        [TestCase(new int[] { 3, 64, 2, 15, 54, 1 }, 24, ExpectedResult = -1)]
        public int IntBinarySearchTest(int[] array, int value)
        {
            return BinarySearch.GenericBinarySearch<int>(array, value);
        }

        [TestCase(new string[] { "ew", "a", "" }, "ew", ExpectedResult = 2)]
        public int StringBinarySearchTest(string[] array, string value)
        {
            int i = BinarySearch.GenericBinarySearch<string>(array, value);
            return BinarySearch.GenericBinarySearch<string>(array, value);
        }
    }
}
