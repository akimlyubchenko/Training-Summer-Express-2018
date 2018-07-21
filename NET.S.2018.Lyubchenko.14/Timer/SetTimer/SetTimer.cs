using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SetTimer
{
    /// <summary>
    /// Set time
    /// </summary>
    public class SetTimer
    {
        public event Action OnAct;

        /// <summary>
        /// Starts the timer.
        /// </summary>
        /// <param name="time">The time</param>
        public void StartTimer(int time)
        {
            Thread.Sleep(time);
            OnAct();
        }
    }
}
