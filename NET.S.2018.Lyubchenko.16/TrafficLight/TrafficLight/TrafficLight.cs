using System;

namespace TrafficLight
{
    /// <summary>
    /// Very simply example for working n-colors trafficlight
    /// </summary>
    public class TrafficLight
    {
        private bool[] cells;
        #region public API        
        /// <summary>
        /// Initializes a new instance of the <see cref="TrafficLight"/> class.
        /// </summary>
        /// <param name="inputCells">The input cells.</param>
        public TrafficLight(params bool[] inputCells)
        {
            cells = new bool[inputCells.Length - 1];
            for (int i = 0; i < inputCells.Length; i++)
            {
                cells[i] = inputCells[i];
            }
        }

        /// <summary>
        /// Sets the cells
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="status">if set to <c>true</c> [status].</param>
        /// <exception cref="System.ArgumentException">Incorrect index</exception>
        public void SetCell(int index, bool status)
        {
            if (index < 0 || index > cells.Length - 1)
            {
                throw new ArgumentException("Incorrect index");
            }

            cells[index] = status;
        }

        /// <summary>
        /// Offs the traffic light.
        /// </summary>
        public void OffTrafficLight()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = false;
            }
        }
        #endregion
    }
}
