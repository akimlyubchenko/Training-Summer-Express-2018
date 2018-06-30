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
            Exceptions(number, degree, precision);
            double x0 = number / degree;
            double x = Equation(number, degree, x0);

            while (Math.Abs(x - x0) > precision)
            {
                x0 = x;
                x = Equation(number, degree, x0);
            }

            return x;
        }
        #endregion
        #region Raises to the power of number
        /// <summary>
        /// Raises to the power of number
        /// </summary>
        /// <param name="number"> Using number </param>
        /// <param name="pow"> Value of a power</param>
        /// <returns> Finished number</returns>
        private static double Pow(double number, int pow)
        {
            double resultExponentiation = 1;
            for (int i = 0; i < pow; i++)
            {
                resultExponentiation *= number;
            }

            return resultExponentiation;
        }
        #endregion
        #region Large formula
        /// <summary>
        /// It's large formula
        /// </summary>
        /// <param name="number"> Number </param>
        /// <param name="degree"> Degree </param>
        /// <param name="x0"> Last x </param>
        /// <returns> Result of the formula </returns>
        private static double Equation(double number, double degree, double x0)
        {
            double x = (1 / degree) * (((degree - 1) * x0) + (number / Pow(x0, (int)degree - 1)));
            return x;
        }
        #endregion
        #region The set of exceptions
        /// <summary>
        /// The set of exceptions
        /// </summary>
        /// <param name="number"> Number </param>
        /// <param name="degree"> Degree </param>
        /// <param name="precision"> Precision </param>
        /// <exception cref="ArgumentException"> 
        /// 3 types exceptions 
        /// </exception>
        private static void Exceptions(double number, double degree, double precision)
        {
            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException($"Number {number} and degree {degree} isn't valid");
            }

            if (degree < 0)
            {
                throw new ArgumentException($"Degree {degree} isn't valid");
            }

            if (precision < 0)
            {
                throw new ArgumentException($"Precision {precision} isn't valid");
            }
        }
        #endregion
    }
}
