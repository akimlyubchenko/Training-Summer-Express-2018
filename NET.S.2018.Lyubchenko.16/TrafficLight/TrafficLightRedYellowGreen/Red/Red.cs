using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightRedYellowGreen.Red
{
    /// <summary>
    /// Red color
    /// </summary>
    /// <seealso cref="TrafficLightRedYellowGreen.ITrafficLightRedYellowGreen" />
    public class Red : ITrafficLightRedYellowGreen
    {
        public bool RedLight { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Red"/> class.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [status].</param>
        public Red(bool status = false)
            => RedLight = status == false ? false : true;

        /// <summary>
        /// Ons this instance.
        /// </summary>
        public void On()
        {
            RedLight = true;
        }

        /// <summary>
        /// Offs this instance.
        /// </summary>
        public void Off()
        {
            RedLight = false;
        }
    }
}
