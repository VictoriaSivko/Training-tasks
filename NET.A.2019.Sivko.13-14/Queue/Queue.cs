using System;
using System.Collections;
using System.Collections.Generic;

namespace Day13Lib
{
    public class Queue<T>: IEnumerable
    {
        private Element<T> head;
        private Element<T> tail;
        public int Count { get; private set; }

        public Queue()
        {
            Count = 0;
        }

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

        public T Dequeue()
        {
            if (Count == 0)
                throw new Exception("The queue does not contain any items");

            T output = head.Data;
            head = head.Next;
            Count--;
            return output;
        }

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

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator<T>(head);
        }

        private class Element<E>
        {
            public E Data { get; set; }
            public Element<E> Next { get; set; }

            public Element(E data)
            {
                Data = data;
            }
        }

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
