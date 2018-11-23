using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task3_Tests
{
    /// <summary>
    /// <see cref="BinaryTreeNode{T}"/> contains references to the left and right subtrees (if there is no subtree, the link is null),
    /// the node data and the <see cref="IComparable.CompareTo(object)"/> method for comparing nodes.
    /// </summary>
    /// <typeparam name="T">Input type</typeparam>
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public T Value { get; set; }
    }   
}
