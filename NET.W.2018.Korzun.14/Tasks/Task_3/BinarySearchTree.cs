using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task3_Tests
{
    /// <summary>
    /// Develop a generic collection class BinarySearchTree (binary search tree).
    /// Provide for the use of a pluggable interface to implement an order relationship.
    /// Implement three ways to traverse the tree:
    /// direct (preorder), transverse (inorder), and reverse (posterorder).
    /// </summary>
    /// <typeparam name="T">Input type</typeparam>
    public sealed class BinarySearchTree<T> : IEnumerable<T>, IEnumerable
    {
        #region private fields
        private readonly Comparison<T> _compare;
        private BinaryTreeNode<T> _head = null;
        private int _count;
        #endregion

        #region constructors

        /// <summary>
        /// Create new object of <see cref="BinarySearchTree{T}"/>/>
        /// </summary>
        public BinarySearchTree() : this((Comparison<T>)null)
        {
        }

        /// <summary>
        /// Create new object of <see cref="BinarySearchTree{T}"/>
        /// </summary>
        /// <param name="comparer">Compare two instances (struct <see cref="Point>"/>)</param>
        public BinarySearchTree(IComparer<T> comparer) : this(comparer.Compare)
        {
        }

        /// <summary>
        /// Create new object of <see cref="Comparison{T}"/>/>
        /// </summary>
        /// <param name="comparison">Compare two instances (class <see cref="Book"/>)</param>
        public BinarySearchTree(Comparison<T> comparison)
        {
            _compare = comparison ?? Comparer<T>.Default.Compare;
        }
        #endregion

        #region properties
        /// <summary>
        /// Returns the number of tree nodes, or 0 if the tree is empty
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }
        #endregion

        #region Methods for Binary Search Tree

        /// <summary>
        /// Add new item in the Binary Tree
        /// </summary>
        /// <param name="item">Input item</param>
        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _head = AddTo(_head, item);
        }

        /// <summary>
        /// Add new collections (array) in the Binary Tree
        /// </summary>
        /// <param name="items">Input collection (array)</param>
        public void Add(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (var item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// <see cref="Contains(T)"/> method to check if there is such a value in the tree
        /// </summary>
        /// <param name="item">Input item</param>
        /// <returns>Bool true if element is exists in the tree</returns>
        public bool Contains(T item)
        {
            return Contains(_head, item);
        }

        /// <summary>
        /// Removes all tree nodes
        /// </summary>
        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        #region enumerable
        /// <summary>
        /// Preorder
        /// </summary>
        /// <returns> IEnumerable (preorder)</returns>
        public IEnumerable<T> PreOrder() => PreOrder(_head);

        /// <summary>
        /// Postorder
        /// </summary>
        /// <returns> IEnumerable (postorder)</returns>
        public IEnumerable<T> PostOrder() => PostOrder(_head);

        /// <summary>
        /// Inorder
        /// </summary>
        /// <returns> IEnumerable (inorder)</returns>
        public IEnumerable<T> InOrder() => InOrder(_head);

        #region implementation IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #endregion

        /// <summary>
        /// Add new item in the Binary Tree
        /// </summary>
        /// <param name="node">object of <see cref="BinaryTreeNode{T}"/></param>
        /// <param name="item">Input value</param>
        /// <returns>Object <see cref="BinaryTreeNode{T}"/></returns>
        private BinaryTreeNode<T> AddTo(BinaryTreeNode<T> node, T item)
        {
            if (node == null)
            {
                return new BinaryTreeNode<T>(item);
            }

            int temp = _compare(item, node.Value);

            if (temp < 0)
            {
                node.Left = AddTo(node.Left, item);
            }
            else if (temp > 0)
            {
                node.Right = AddTo(node.Right, item);
            }

            return node;
        }

        /// <summary>
        /// Returns true if the value is contained in the tree. Otherwise, returns false.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="item"></param>
        /// <returns>
        /// <true>
        /// if the value is contained in the tree,
        /// </true>
        /// <false>
        /// Otherwise, returns false.
        /// </false>
        /// </returns>
        private bool Contains(BinaryTreeNode<T> node, T item)
        {
            if (node == null)
            {
                return false;
            }

            int temp = _compare(node.Value, item);

            if (temp == 0)
            {
                return true;
            }
            else if (temp < 0)
            {
                return Contains(node.Right, item);
            }
            else
            {
                return Contains(node.Left, item);
            }
        }
        #endregion        

        #region tree traversals
        private IEnumerable<T> PreOrder(BinaryTreeNode<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
            {
                foreach (var item in PreOrder(node.Left))
                {
                    yield return item;
                }
            }              
                    
            if (node.Right != null)
            {
                foreach (var item in PreOrder(node.Right))
                {
                    yield return item;
                }
            }        
        }

        private IEnumerable<T> InOrder(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
            {
                foreach (var item in InOrder(node.Left))
                {
                    yield return item;
                }
            } 

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var item in InOrder(node.Right))
                {
                    yield return item;
                }
            }                  
        }

        private IEnumerable<T> PostOrder(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
            {
                foreach (var item in PostOrder(node.Left))
                {
                    yield return item;
                }
            }      

            if (node.Right != null)
            {
                foreach (var item in PostOrder(node.Right))
                {
                    yield return item;
                }
            }

            yield return node.Value;
        }
        #endregion
    }
}