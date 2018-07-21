using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Subscribers
{
    /// <summary>
    /// First Subscriber
    /// </summary>
    public class Subscriber1
    {
        private readonly int time;

        public Subscriber1(int time)
        {
            this.time = time;
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="st">The st.</param>
        public void Register(SetTimer.SetTimer st)
            => st.ActualEvent += Message;

        /// <summary>
        /// UnRegistration
        /// </summary>
        /// <param name="st">The st.</param>
        public void UnRegister(SetTimer.SetTimer st)
            => st.ActualEvent -= Message;

        /// <summary>
        /// Messages this instance.
        /// </summary>
        private void Message(object sb, SmthEvent.SmthEvent sm)
        {
            Thread.Sleep(time);
            Console.WriteLine("Act was happend(Subscriber1)");
            Console.WriteLine($"Time sleep =  {time}, Message = {sm.Message}\n");
        }
    }

    /// <summary>
    /// Second Subscriber
    /// </summary>
    public class Subscriber2
    {
        private readonly int time;

        public Subscriber2(int time)
        {
            this.time = time;
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="st">The st.</param>
        public void Register(SetTimer.SetTimer st)
            => st.ActualEvent += Message;

        /// <summary>
        /// UnRegistration
        /// </summary>
        /// <param name="st">The st.</param>
        public void UnRegister(SetTimer.SetTimer st)
            => st.ActualEvent -= Message;

        /// <summary>
        /// Messages this instance.
        /// </summary>
        private void Message(object sb, SmthEvent.SmthEvent sm)
        {
            Thread.Sleep(time);
            Console.WriteLine("Act was happend(Subscriber2)");
            Console.WriteLine($"Time sleep =  {time}, Message = {sm.Message}\n");
        }
    }
}
