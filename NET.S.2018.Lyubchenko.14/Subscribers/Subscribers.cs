using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscribers
{
    public class Subscriber1
    {
        public void Message()
        {
            Console.WriteLine("Act was happend(Subscriber1)");
        }
            
    }

    public class Subscriber2
    {
        public void Message()
        {
            Console.WriteLine("Act was happend(Subscriber2)");
        }
    }
}
