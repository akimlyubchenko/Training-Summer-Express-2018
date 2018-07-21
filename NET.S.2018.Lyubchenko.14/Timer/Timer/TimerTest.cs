using System;

namespace Timer
{
    class TimerTest
    {
        static void Main(string[] args)
        {
            SetTimer.SetTimer manager = new SetTimer.SetTimer();
            Subscribers.Subscriber1 firstSub = new Subscribers.Subscriber1(1000);
            Subscribers.Subscriber2 secondSub = new Subscribers.Subscriber2(1500);
            firstSub.Register(manager);
            secondSub.Register(manager);
            manager.SimulateSubj("First event start");
            secondSub.UnRegister(manager);
            manager.SimulateSubj("Second even start");
            secondSub = new Subscribers.Subscriber2(500);
            secondSub.Register(manager);
            firstSub.UnRegister(manager);
            manager.SimulateSubj("Third even start");

            Console.ReadKey();
        }
    }
}
