using System;

namespace SmthEvent
{
    public class SmthEvent : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmthEvent"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public SmthEvent(string message)
            => Message = message;

        public string Message { get; private set; }
    }
}
