using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightRedYellowGreen.Yellow
{
    /// <summary>
    /// Yellow color
    /// </summary>
    /// <seealso cref="TrafficLightRedYellowGreen.ITrafficLightRedYellowGreen" />
    public class Yellow : ITrafficLightRedYellowGreen
    {
        public bool YellowLight { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Yellow"/> class.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [status].</param>
        public Yellow(bool status = false)
            => YellowLight = status == false ? false : true;

        /// <summary>
        /// Ons this instance.
        /// </summary>
        public void On()
        {
            YellowLight = true;
        }

        /// <summary>
        /// Offs this instance.
        /// </summary>
        public void Off()
        {
            YellowLight = false;
        }
    }
}
