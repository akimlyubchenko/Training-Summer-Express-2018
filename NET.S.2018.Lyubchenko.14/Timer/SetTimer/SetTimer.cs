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
        /// <summary>
        /// The event
        /// </summary>
        public EventHandler<SmthEvent.SmthEvent> ActualEvent;

        /// <summary>
        /// Simulates the subject.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SimulateSubj(string message)
     => OnEvent(this, new SmthEvent.SmthEvent(message));

        private void OnEvent(object subscriber, SmthEvent.SmthEvent smth)
            => ActualEvent?.Invoke(subscriber, smth);
    }
}
