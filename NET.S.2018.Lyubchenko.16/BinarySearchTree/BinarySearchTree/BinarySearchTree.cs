using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Binary Search Tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T>
    {
        private readonly IComparer<T> comparer = Comparer<T>.Default;
        public Node<T> Head;

        #region public API        
        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree() { }

        /// <summary>
        /// Initializes a new instance width array of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="elements">The elements.</param>
        public BinarySearchTree(IEnumerable<T> elements)
        {
            if (elements == null)
            {
                Head = null;
                return;
            }

            foreach (var el in elements)
            {
                Add(el);
            }
        }

        /// <summary>
        /// Adds the specified el.
        /// </summary>
        /// <param name="el">The el.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Add(T el)
        {
            if (el == null)
            {
                throw new ArgumentNullException($"Fill element type of {typeof(T)}");
            }

            if (Head == null)
            {
                Head = new Node<T>(el);
                return;
            }

            FindPlace(Head, el);
        }

        /// <summary>
        /// PreOrder sort
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Fill tree</exception>
        public IEnumerable<T> PreOrder()
        {
            if (Head == null)
            {
                throw new ArgumentException("Fill tree");
            }

            return PreOrder(Head);
        }

        /// <summary>
        /// InOrder sort
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Fill tree</exception>
        public IEnumerable<T> InOrder()
        {
            if (Head == null)
            {
                throw new ArgumentException("Fill tree");
            }

            return InOrder(Head);
        }

        /// <summary>
        /// PostsOrder sort
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Fill tree</exception>
        public IEnumerable<T> PostOrder()
        {
            if (Head == null)
            {
                throw new ArgumentException("Fill tree");
            }

            return PostOrder(Head);
        }
        #endregion
        #region private methods
        private IEnumerable<T> PreOrder(Node<T> head)
        {
            yield return head.Current;
            if (head.Prev != null)
            {
                foreach (var el in PreOrder(head.Prev))
                {
                    yield return el;
                }
            }

            if (head.Next != null)
            {
                foreach (var el in PreOrder(head.Next))
                {
                    yield return el;
                }
            }
        }

        private IEnumerable<T> InOrder(Node<T> head)
        {
            if (head.Prev != null)
            {
                foreach (var el in InOrder(head.Prev))
                {
                    yield return el;
                }
            }

            yield return head.Current;

            if (head.Next != null)
            {
                foreach (var el in InOrder(head.Next))
                {
                    yield return el;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> head)
        {
            if (head.Prev != null)
            {
                foreach (var el in PostOrder(head.Prev))
                {
                    yield return el;
                }
            }

            if (head.Next != null)
            {
                foreach (var el in PostOrder(head.Next))
                {
                    yield return el;
                }
            }

            yield return head.Current;
        }

        private void FindPlace(Node<T> head, T el)
        {
            if (comparer.Compare(head.Current, el) > 0)
            {
                if (head.Prev == null)
                {
                    head.Prev = new Node<T>(el);
                }

                FindPlace(head.Prev, el);
            }
            else if (comparer.Compare(head.Current, el) < 0)
            {
                if (head.Next == null)
                {
                    head.Next = new Node<T>(el);
                }

                FindPlace(head.Next, el);
            }
        }
        #endregion
    }
}
