using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Subscribers.Subscriber1;

namespace Timer
{
    class TimerTest
    {
        static void Main(string[] args)
        {
            SetTimer.SetTimer time = new SetTimer.SetTimer();
            Subscribers.Subscriber1 firstSub = new Subscribers.Subscriber1();
            Subscribers.Subscriber2 secondSub = new Subscribers.Subscriber2();
            time.OnAct += firstSub.Message;
            time.OnAct += secondSub.Message;
            time.StartTimer(1000);

            Console.ReadKey();
        }
    }
}
