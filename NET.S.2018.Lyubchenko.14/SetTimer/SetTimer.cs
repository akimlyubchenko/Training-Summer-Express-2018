using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SetTimer
{
    public class SetTimer
    {
        public delegate void DoSmth();
        public event DoSmth OnAct;

        public void StartTimer(int time)
        {
            Thread.Sleep(time);
            OnAct();
        }
    }
}
