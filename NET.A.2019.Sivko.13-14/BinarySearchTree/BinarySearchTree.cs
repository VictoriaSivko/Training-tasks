using System;
using System.Collections;
using System.Collections.Generic;

namespace Day13Lib
{
    /// <summary>
    /// Node relative to parent.
    /// </summary>
    public enum Side
    {
        Left,
        Right
    }

    /// <summary>
    /// Implements a binary search tree.
    /// </summary>
    /// <typeparam name="T">Type of data stored in the BinarySearchTree.</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable
    {
        /// <summary>
        /// The root element of the tree.
        /// </summary>
        public BinaryTreeNode<T> RootNode { get; set; }

        /// <summary>
        /// Adds a new node to the tree.
        /// </summary>
        /// <param name="node">New node.</param>
        /// <param name="currentNode">Current node of the tree.</param>
        public void Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (node == null)
                return;

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

        /// <summary>
        /// Adds a new node to the tree.
        /// </summary>
        /// <param name="data">Information for the new node.</param>
        public void Add(T data)
        {
            Add(new BinaryTreeNode<T>(data));
        }

        /// <summary>
        /// Searches for a matching node.
        /// </summary>
        /// <param name="data">Required data.</param>
        /// <param name="startNode">Start node.</param>
        /// <returns>Result of search.</returns>
        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startNode = null)
        {
            if (data == null)
                return null;

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

        /// <summary>
        /// Searches for a matching node.
        /// </summary>
        /// <param name="data">Required data.</param>
        /// <param name="comparer">Search algorithm.</param>
        /// <param name="startNode">Start node.</param>
        /// <returns>Result of search.</returns>
        public BinaryTreeNode<T> FindNode(T data, IComparer<T> comparer, BinaryTreeNode<T> startNode = null)
        {
            if (data == null)
                return null;

            startNode = startNode ?? RootNode;

            int result = comparer.Compare(data, startNode.Data);

            if (result == 0)
                return startNode;
            else if (result < 0)
            {
                if (startNode.LeftNode != null)
                    return FindNode(data, comparer, startNode.LeftNode);
                else
                    return null;
            }
            else
            {
                if (startNode.RightNode != null)
                    return FindNode(data, comparer, startNode.RightNode);
                else
                    return null;
            }
        }

        /// <summary>
        /// Iterates through a collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return PreOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Pre order traversal.
        /// </summary>
        /// <returns>Collection of the data.</returns>
        public IEnumerable<T> PreOrder()
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

        /// <summary>
        /// On Order traversal.
        /// </summary>
        /// <returns>Collection of the data.</returns>
        public IEnumerable<T> InOrder()
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

        /// <summary>
        /// Post Order traversal.
        /// </summary>
        /// <returns>Collection of the data.</returns>
        public IEnumerable<T> PostOrder()
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

    /// <summary>
    /// Implement a node of the tree.
    /// </summary>
    /// <typeparam name="T">Type of data stored in the BinarySearchTree.</typeparam>
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

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
