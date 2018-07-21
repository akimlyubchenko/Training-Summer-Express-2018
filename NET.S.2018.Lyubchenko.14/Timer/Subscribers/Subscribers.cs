using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscribers
{
    /// <summary>
    /// First Subscriber
    /// </summary>
    public class Subscriber1
    {
        /// <summary>
        /// Messages this instance.
        /// </summary>
        public void Message()
        {
            Console.WriteLine("Act was happend(Subscriber1)");
        }
            
    }

    /// <summary>
    /// Second Subscriber
    /// </summary>
    public class Subscriber2
    {
        /// <summary>
        /// Messages this instance.
        /// </summary>
        public void Message()
        {
            Console.WriteLine("Act was happend(Subscriber2)");
        }
    }
}
