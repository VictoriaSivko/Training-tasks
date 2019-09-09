using System;
using System.Collections;
using System.Collections.Generic;

namespace Day13Lib
{
    /// <summary>
    /// Implements the queue.
    /// </summary>
    /// <typeparam name="T">Type of data stored in the queue.</typeparam>
    public class Queue<T>: IEnumerable
    {
        private Element<T> head;
        private Element<T> tail;

        /// <summary>
        /// Number of items in queue.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Initializes the queue object.
        /// </summary>
        public Queue()
        {
            Count = 0;
        }

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <param name="data">Data.</param>
        public void Enqueue(T data)
        {
            Element<T> element = new Element<T>(data);
            Element<T> temp = tail;
            tail = element;

            if (Count == 0)
                head = tail;
            else
                temp.Next = tail;

            Count++;
        }

        /// <summary>
        /// Removes items from the queue.
        /// </summary>
        /// <returns>Delete items.</returns>
        public T Dequeue()
        {
            if (Count == 0)
                throw new Exception("The queue does not contain any items");

            T output = head.Data;
            head = head.Next;
            Count--;
            return output;
        }

        /// <summary>
        /// Gets the first item in the queue.
        /// </summary>
        public T Peek
        {
            get
            {
                if (Count == 0)
                    throw new Exception("The queue does not contain any items");
                else
                    return head.Data;
            }
        }

        /// <summary>
        /// Clears the queue.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Checks whether the queue contains the desired item.
        /// </summary>
        /// <param name="data">The desired element.</param>
        /// <returns>Test result.</returns>
        public bool Contains(T data)
        {
            Element<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Iterates through a collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator<T>(head);
        }

        /// <summary>
        /// One element of the queue.
        /// </summary>
        /// <typeparam name="E">The type of queue item.</typeparam>
        private class Element<E>
        {
            public E Data { get; set; }
            public Element<E> Next { get; set; }

            public Element(E data)
            {
                Data = data;
            }
        }

        /// <summary>
        /// Helper class to crawl the collection.
        /// </summary>
        /// <typeparam name="E">Queue type</typeparam>
        private class MyEnumerator<E> : IEnumerator<E>
        {
            private Element<E> head;

            public MyEnumerator(Element<E> head)
            {
                this.head = head;
            }

            public E Current
            {
                get
                {
                    if (head == null)
                        throw new InvalidOperationException();
                    else
                    {
                        E output = head.Data;
                        head = head.Next;

                        return output;
                    }
                }
            }

            object IEnumerator.Current { get { return Current; } }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (head != null)
                    return true;
                else
                    return false;
            }

            public void Reset()
            {
                head = null;
            }
        }
    }
}
