using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    /// <summary>
    /// Node info
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T Current { get; private set; }
        public Node<T> Next;
        public Node<T> Prev;
        public Node<T> Parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Node(T value, Node<T> par = null)
        {
            Current = value;
            Parent = par;
            Next = null;
            Prev = null;
        }

        public bool Remove(ref Node<T> Head)
        {
            if (Parent == null)
            {
                Next.Parent = Prev.LastElSearcher();
                var temp = Next;
                Head = Prev;
                Head.Parent = null;
                Head.Next = temp;
                return true;
            }

            return Parent.ChangeParent(this);
        }

        private bool ChangeParent(Node<T> current)
        {
            if (Current == null)
            {
                current.Prev.Parent = null;
                current.Next.Parent = current.Prev;
                return true;
            }

            if (Next == current)
            {
                CheckParent(ref Next, current);
                return true;
            }
            else if (Prev == current)
            {
                CheckParent(ref Prev, current);
                return true;
            }

            return false;
        }

        private void CheckParent(ref Node<T> pn, Node<T> current)
        {
            if (current.Next == null && current.Prev == null)
            {
                pn = null;
                current = null;
                return;
            }
            else if (pn.Next != null && pn.Prev == null)
            {
                pn = current.Next;
                current.Next.Parent = current.Parent;
                return;
            }
            else if (pn.Prev != null && pn.Next == null)
            {
                pn = current.Prev;
                current.Prev.Parent = current.Parent;
                return;
            }

            Node<T> temp = pn.Prev.LastElSearcher();
            pn.Next.Parent = temp;
            temp.Next = pn.Next.Parent;
            pn = null;
        }

        private Node<T> LastElSearcher()
        {
            if (Next != null)
            {
                return Next.LastElSearcher();
            }

            return this;
        }

    }
}
