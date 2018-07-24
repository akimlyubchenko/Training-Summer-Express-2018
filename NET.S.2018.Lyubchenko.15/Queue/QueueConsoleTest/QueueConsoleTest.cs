using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueConsoleTest
{
    class QueueConsoleTest
    {
        static void Main(string[] args)
        {
            Queue.Queue<int> a = new Queue.Queue<int>(5, 3, 8, 2);
            a.Enqueue(1);
            a.Enqueue(2);
            a.Enqueue(3);
            a.Enqueue(4);
            a.Enqueue(5);
            a.Enqueue(6);
            a.Dequeue();
            Console.WriteLine("Contains  {0}\t Count  {1}\nMoveNext  {2}\t Current  {3}",
                a.Contains(2), a.Count(), a.MoveNext(3), a.Current);
            a.Show();
            a.DeqeueAt(a.Current);
            a.Show();


            Queue.Queue<int> b = new Queue.Queue<int>(5, 3, 8, 2);
            b.Enqueue(1);
            b.Enqueue(2);
            b.Enqueue(3);
            b.Enqueue(4);
            b.Enqueue(5);
            b.Enqueue(6);

            Console.WriteLine(Equals(a, b));
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());
            Console.ReadKey();
        }
    }
}
