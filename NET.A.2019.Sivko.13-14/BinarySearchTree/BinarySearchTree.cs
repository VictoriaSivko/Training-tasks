using System;
using System.Collections;
using System.Collections.Generic;

namespace Day13Lib
{
    public enum Side
    {
        Left,
        Right
    }

    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable
    {
        public BinaryTreeNode<T> RootNode { get; set; }

        public void Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                RootNode = node;
                return;
            }

            currentNode = currentNode ?? RootNode;

            node.ParentNode = currentNode;

            int result = node.Data.CompareTo(currentNode.Data);

            if (result == 0)
                return;
            else if (result < 0)
            {
                if (currentNode.LeftNode == null)
                    currentNode.LeftNode = node;
                else
                    Add(node, currentNode.LeftNode);
            }
            else
            {
                if (currentNode.RightNode == null)
                    currentNode.RightNode = node;
                else
                    Add(node, currentNode.RightNode);
            }
        }

        public void Add(T data)
        {
            Add(new BinaryTreeNode<T>(data));
        }

        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startNode = null)
        {
            startNode = startNode ?? RootNode;

            int result = data.CompareTo(startNode.Data);

            if (result == 0)
                return startNode;
            else if (result < 0)
            {
                if (startNode.LeftNode != null)
                    return FindNode(data, startNode.LeftNode);
                else
                    return null;
            }
            else
            {
                if (startNode.RightNode != null)
                    return FindNode(data, startNode.RightNode);
                else
                    return null;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return PreOrder();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> PreOrder()
        {
            BinaryTreeNode<T> current = RootNode;
            BinaryTreeNode<T> lastNode = null;

            while (current != null)
            {
                if (lastNode == current.ParentNode)
                {
                    yield return current.Data;

                    if (current.LeftNode != null)
                    {
                        lastNode = current;
                        current = current.LeftNode;
                        continue;
                    }
                    else
                        lastNode = null;
                }

                if (lastNode == current.LeftNode)
                {

                    if (current.RightNode != null)
                    {
                        lastNode = current;
                        current = current.RightNode;
                        continue;
                    }
                    else
                        lastNode = null;
                }

                if (lastNode == current.RightNode)
                {
                    lastNode = current;
                    current = current.ParentNode;
                }
            }
        }

        public IEnumerator<T> InOrder()
        {
            BinaryTreeNode<T> current = RootNode;
            BinaryTreeNode<T> lastNode = null;

            while (current != null)
            {
                if (lastNode == current.ParentNode)
                {
                    if (current.LeftNode != null)
                    {
                        lastNode = current;
                        current = current.LeftNode;
                        continue;
                    }
                    else
                        lastNode = null;
                }

                if (lastNode == current.LeftNode)
                {
                    yield return current.Data;

                    if (current.RightNode != null)
                    {
                        lastNode = current;
                        current = current.RightNode;
                        continue;
                    }
                    else
                        lastNode = null;
                }

                if (lastNode == current.RightNode)
                {
                    lastNode = current;
                    current = current.ParentNode;
                }
            }
        }

        public IEnumerator<T> PostOrder()
        {
            BinaryTreeNode<T> current = RootNode;

            BinaryTreeNode<T> lastNode = null;

            while (current != null)
            {
                if (lastNode == current.ParentNode)
                {
                    if (current.LeftNode != null)
                    {
                        lastNode = current;
                        current = current.LeftNode;
                        continue;
                    }
                    else
                        lastNode = null;
                }

                if (lastNode == current.LeftNode)
                {


                    if (current.RightNode != null)
                    {
                        lastNode = current;
                        current = current.RightNode;
                        continue;
                    }
                    else
                        lastNode = null;
                }

                if (lastNode == current.RightNode)
                {
                    yield return current.Data;

                    lastNode = current;
                    current = current.ParentNode;
                }
            }

        }
    }

    public class BinaryTreeNode<T> : IComparable<T> where T : IComparable
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> LeftNode { get; set; }
        public BinaryTreeNode<T> RightNode { get; set; }
        public BinaryTreeNode<T> ParentNode { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public Side? NodeSide()
        {
            if (ParentNode == null)
                return (Side?)null;
            else
                return ParentNode.LeftNode == this ? Side.Left : Side.Right;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}
