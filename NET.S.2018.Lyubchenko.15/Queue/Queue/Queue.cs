using System;
using System.Collections.Generic;

namespace Queue
{
    /// <summary>
    /// Generic Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        private List<T> list;
        public int Current { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            list = new List<T>();
            Current = -1;
        }

        /// <summary>
        /// Initializes a new instance width params.
        /// </summary>
        /// <param name="arr">The arr.</param>
        public Queue(params T[] arr) : this()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                ElementValidator(arr[i]);
                list.Add(arr[i]);
            }

            Current = -1;
        }

        /// <summary>
        /// Add T element
        /// </summary>
        /// <param name="obj">The object.</param>
        public void Enqueue(T obj)
        {
            ElementValidator(obj);
            list.Add(obj);
        }

        /// <summary>
        /// Remove 0th element
        /// </summary>
        /// <returns> Removed element </returns>
        public T Dequeue()
        {
            T el = list[0];
            list.Remove(list[0]);
            return el;
        }

        /// <summary>
        /// Remove element of specified index
        /// </summary>
        /// <param name="index">The index.</param>
        public void DeqeueAt(int index)
            => list.RemoveAt(index);

        /// <summary>
        /// Clears this queue
        /// </summary>
        public void Clear()
            => list = new List<T>();

        /// <summary>
        /// Determines if contains T el
        /// </summary>
        /// <param name="el">The el.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified el]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T el)
            => list.IndexOf(el) != -1 ? true : false;

        /// <summary>
        /// Shows this queue
        /// </summary>
        public void Show()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i, list[i]);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Moves the next current index
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <returns> true if operation have success </returns>
        public bool MoveNext(int steps = 1)
        {
            if (Current + steps - 1 < list.Count)
            {
                Current += steps;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Moves the previous current index
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <returns> true if operation have success </returns>
        public bool MovePrev(int steps = 1)
        {
            if (Current - steps + 1 > -1)
            {
                Current -= steps;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Resets current index
        /// </summary>
        public void Reset()
            => Current = -1;

        /// <summary>
        /// Counts length of queue
        /// </summary>
        /// <returns></returns>
        public int Count()
            => list.Count;

        private void ElementValidator(T el)
        {
            if (el == null)
            {
                throw new ArgumentNullException($"Introduced {typeof(T)} don't be null");
            }
        }
    }
}
