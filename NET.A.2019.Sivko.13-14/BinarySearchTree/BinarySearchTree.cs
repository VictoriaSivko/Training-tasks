using System;

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
                node.ParentNode = null;
        }
    }

    public class BinaryTreeNode<T> where T : IComparable
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
    }
}
