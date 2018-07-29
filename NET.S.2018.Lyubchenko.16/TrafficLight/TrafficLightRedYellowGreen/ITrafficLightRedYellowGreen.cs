using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightRedYellowGreen
{
    /// <summary>
    /// Ons or offs trafficlight's cells
    /// </summary>
    public interface ITrafficLightRedYellowGreen
    {
        /// <summary>
        /// Ons this instance.
        /// </summary>
        void On();

        /// <summary>
        /// Offs this instance.
        /// </summary>
        void Off();
    }
}
