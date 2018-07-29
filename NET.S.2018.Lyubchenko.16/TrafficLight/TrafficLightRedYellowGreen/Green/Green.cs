using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightRedYellowGreen.Green
{
    /// <summary>
    /// Green color
    /// </summary>
    /// <seealso cref="TrafficLightRedYellowGreen.ITrafficLightRedYellowGreen" />
    public class Green : ITrafficLightRedYellowGreen
    {
        public bool GreenLight { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Green"/> class.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [status].</param>
        public Green(bool status = false)
            => GreenLight = status == false ? false : true;

        /// <summary>
        /// Ons this instance.
        /// </summary>
        public void On()
        {
            GreenLight = true;
        }

        /// <summary>
        /// Offs this instance.
        /// </summary>
        public void Off()
        {
            GreenLight = false;
        }
    }
}
