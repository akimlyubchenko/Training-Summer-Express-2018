using System;

namespace RootCalculator
{
    /// <summary>
    /// Calculates root n of the number
    /// </summary>
    public class RootCalculator
    {
        #region Calculates root n of the number
        /// <summary>
        /// Calculates root n of the number
        /// </summary>
        /// <param name="number"> Using number</param>
        /// <param name="degree"> Degree of root </param>
        /// <param name="precision"> Precision </param>
        /// <returns> Finished number </returns>
        public static double FindNthRoot(double number, double degree, double precision = 0.0000001)
        {
            IsValid(number, degree, precision);
            double firstValue = number / degree;
            double lastValue = Equation(number, degree, firstValue);

            while (Math.Abs(lastValue - firstValue) > precision)
            {
                firstValue = lastValue;
                lastValue = Equation(number, degree, firstValue);
            }

            return lastValue;
        }
        #endregion
        #region Large formula
        /// <summary>
        /// It's large formula
        /// </summary>
        /// <param name="number"> Number </param>
        /// <param name="degree"> Degree </param>
        /// <param name="firstValue"> Last value </param>
        /// <returns> Result of the formula </returns>
        private static double Equation(double number, int degree, double firstValue)
            => (1.0 / degree) * (((degree - 1) * firstValue) + (number / Math.Pow(firstValue, degree - 1)));

        #endregion
        #region The set of IsValid
        /// <summary>
        /// The set of IsValid
        /// </summary>
        /// <param name="number"> Number </param>
        /// <param name="degree"> Degree </param>
        /// <param name="precision"> Precision </param>
        /// <exception cref="ArgumentException"> 
        /// 3 types IsValid 
        /// </exception>
        private static void IsValid(double number, double degree, double precision)
        {
            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException($"Number {number} and degree {degree} isn't valid");
            }

            if (degree < 0)
            {
                throw new ArgumentException($"Degree {degree} isn't valid");
            }

            if (precision < 0 || precision >= 1)
            {
                throw new ArgumentException($"Precision {precision} isn't valid");
            }
        }
        #endregion
    }
}
