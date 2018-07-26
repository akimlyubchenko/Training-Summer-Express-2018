using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {
        private readonly IComparer<T> comparer;
        public Node<T> Head;

        #region public API
        public BinarySearchTree()
            => comparer = Comparer<T>.Default;

        public BinarySearchTree(IEnumerable<T> elements, IComparer<T> comp = null)
        {
            if (comp == null)
            {
                comparer = Comparer<T>.Default;
            }

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

        public IEnumerable<T> PreOrder()
        {
            if (Head == null)
            {
                throw new ArgumentException("Fill tree");
            }

            return PreOrder(Head);
        }

        public IEnumerable<T> PreOrder(Node<T> head)
        {
            yield return head.Current;
            foreach (var el in PreOrder(head.Prev))
            {
                yield return el;
            }

            foreach (var el in PreOrder(head.Next))
            {
                yield return el;
            }

        }
        #endregion
        #region private methods
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
