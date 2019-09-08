using System;
using NUnit.Framework;
using Day13Lib;

namespace Day13Test
{
    [TestFixture]
    public class QueueTest
    {
        [TestCase (4, 6, 43, 478, ExpectedResult = "4 6 43 478 ")]
        public string EnQueueTest(params int[] array)
        {
            Queue<int> queue = new Queue<int>();
            string actual = "";

            for (int i = 0; i < array.Length; i++)
                queue.Enqueue(array[i]);

            foreach (int item in queue)
                actual += item + " ";

            return actual;
        }

        [TestCase(4, 6, 43, 478, ExpectedResult = 4)]
        public int DeQueueTest(params int[] array)
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < array.Length; i++)
                queue.Enqueue(array[i]);

            return queue.Dequeue();
        }

        [TestCase(4, 6, 43, 478, ExpectedResult = 4)]
        public int PeekTest(params int[] array)
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < array.Length; i++)
                queue.Enqueue(array[i]);

            return queue.Peek;
        }

        [TestCase(4, 6, 43, 478, ExpectedResult = false)]
        [TestCase(4, 6, 4, 478, ExpectedResult = true)]
        public bool ContainsTest(int element, params int[] array)
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < array.Length; i++)
                queue.Enqueue(array[i]);

            return queue.Contains(element);
        }

        [Test]
        public void DequeueException()
        {
            Queue<string> queue = new Queue<string>();
            string actual;
            var ex = Assert.Catch<Exception>(() => actual = queue.Dequeue());
            StringAssert.Contains("The queue does not contain any items", ex.Message);
        }

        [Test]
        public void PeekException()
        {
            Queue<string> queue = new Queue<string>();
            string actual;
            var ex = Assert.Catch<Exception>(() => actual = queue.Peek);
            StringAssert.Contains("The queue does not contain any items", ex.Message);
        }
    }
}
