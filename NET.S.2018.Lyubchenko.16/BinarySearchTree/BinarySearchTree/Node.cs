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

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Node(T value)
        {
            Current = value;
            Next = null;
            Prev = null;
        }
    }
}
