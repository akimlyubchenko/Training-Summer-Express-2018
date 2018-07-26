using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node<T>
    {
        public T Current { get; private set; }
        public Node<T> Next;
        public Node<T> Prev;

        public Node(T value)
        {
            Current = value;
            Next = null;
            Prev = null;
        }
    }
}
