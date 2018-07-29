using System;

namespace TrafficLightRedYellowGreen
{
    /// <summary>
    /// TrafficLight for auto
    /// </summary>
    class TrafficLightRedYellowGreen
    {
        #region private Fields
        private Red.Red RedLight;
        private Yellow.Yellow YellowLight;
        private Green.Green GreenLight;
        #endregion
        #region public API        
        /// <summary>
        /// Initializes a new instance of the <see cref="TrafficLightRedYellowGreen"/> class widthout instructions
        /// </summary>
        public TrafficLightRedYellowGreen()
        {
            RedLight = new Red.Red();
            YellowLight = new Yellow.Yellow();
            GreenLight = new Green.Green();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrafficLightRedYellowGreen"/> class width instructions
        /// </summary>
        /// <param name="RedLight">Status of color red</param>
        /// <param name="YellowLight">Status of color yellow</param>
        /// <param name="GreenLight">Status of color green</param>
        /// <exception cref="System.ArgumentException">
        /// Invalid combination
        /// </exception>
        public TrafficLightRedYellowGreen(bool RedLight, bool YellowLight, bool GreenLight)
        {
            if (RedLight == true && YellowLight == true && GreenLight == true)
            {
                throw new ArgumentException("Invalid combination");
            }
            else if (RedLight == false && YellowLight == true && GreenLight == true)
            {
                throw new ArgumentException("Invalid combination");
            }
            else if (RedLight == true && YellowLight == false && GreenLight == true)
            {
                throw new ArgumentException("Invalid combination");
            }

            this.RedLight = new Red.Red(RedLight);
            this.YellowLight = new Yellow.Yellow(YellowLight);
            this.GreenLight = new Green.Green(GreenLight);
        }

        /// <summary>
        /// Only red color
        /// </summary>
        public void Red()
        {
            RedLight.On();
            YellowLight.Off();
            GreenLight.Off();
        }

        /// <summary>
        /// Only green color
        /// </summary>
        public void Green()
        {
            RedLight.Off();
            YellowLight.Off();
            GreenLight.On();
        }

        /// <summary>
        /// Red and yellow colors
        /// </summary>
        public void RedYellow()
        {
            RedLight.On();
            YellowLight.On();
            GreenLight.Off();
        }

        /// <summary>
        /// Only yellow color
        /// </summary>
        public void Yellow()
        {
            RedLight.Off();
            YellowLight.On();
            GreenLight.Off();
        }
        #endregion
    }
}
