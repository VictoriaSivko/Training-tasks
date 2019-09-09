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

    public class BinarySearchTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> RootNode { get; set; }

        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode)
        {
            if (node.ParentNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;

            node.ParentNode = currentNode;

            int result = node.Data.CompareTo(currentNode.Data);

            if (result == 0)
                return currentNode;
            else if (result < 0)
            {
                if (currentNode.LeftNode == null)
                    return currentNode.LeftNode = node;
                else
                    return Add(node, currentNode.LeftNode);
            }
            else
            {
                if (currentNode.RightNode == null)
                    return currentNode.RightNode = node;
                else
                    return Add(node, currentNode.RightNode);
            }
        }

        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }

        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startNode = null)
        {
            startNode = startNode ?? RootNode;

            int result = data.CompareTo(startWithNode.Data);

            if (result == 0)
                return startNode;
            else if (result < 0)
            {
                if (startWithNode.LeftNode != null)
                    return FindNode(data, startWithNode.LeftNode);
                else
                    return null;
            }
            else
            {
                if (startWithNode.RightNode != null)
                    return FindNode(data, startWithNode.RightNode);
                else
                    return null;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class BinaryTreeNode<T> : IComparable<T>  where T : IComparable
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
