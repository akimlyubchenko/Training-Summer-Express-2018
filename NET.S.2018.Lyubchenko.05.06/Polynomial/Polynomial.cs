using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    /// <summary>
    /// Generate polynomial
    /// </summary>
    public class Polynomial
    {
        #region public API        
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefs"> The numbers of equation </param>
        public Polynomial(double[] coefs)
        {
            IsValid(coefs);
            Coefs = coefs;
            Degree = Coefs.Length - 1;
        }
        #endregion        
        /// <summary>
        /// Gets or sets the array of numbers.
        /// </summary>
        /// <value>
        /// The array.
        /// </value>
        private double[] Coefs { get; set; }
        /// <summary>
        /// Gets or sets the degree.
        /// </summary>
        /// <value>
        /// The degree.
        /// </value>
        private int Degree { get; set; }
        #region Overrides        
        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="pol1">The pol1.</param>
        /// <param name="pol2">The pol2.</param>
        /// <returns>
        /// Sum pol1 and pol2
        /// </returns>
        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            if (pol1.Degree == pol2.Degree)
            {
                double[] doneCoefs = new double[pol2.Degree + 1];
                for (int i = 0; i <= pol1.Degree; i++)
                {
                    doneCoefs[i] = pol1.Coefs[i] + pol2.Coefs[i];
                }

                Polynomial donePol = new Polynomial(doneCoefs);
                return donePol;
            }
            else if (pol1.Degree > pol2.Degree)
            {
                Polynomial donePol = OperatorPlusHelper(pol1, pol2);
                return donePol;
            }
            else if (pol2.Degree > pol1.Degree)
            {
                Polynomial donePol = OperatorPlusHelper(pol2, pol1);
                return donePol;
            }

            return null;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="pol1">The pol1.</param>
        /// <param name="pol2">The pol2.</param>
        /// <returns>
        /// The result of the operator -.
        /// </returns>
        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            if (pol1.Degree == pol2.Degree)
            {
                double[] doneCoefs = new double[pol2.Degree + 1];
                for (int i = 0; i <= pol1.Degree; i++)
                {
                    doneCoefs[i] = pol1.Coefs[i] - pol2.Coefs[i];
                }

                Polynomial donePol = new Polynomial(doneCoefs);
                return donePol;
            }
            else if (pol1.Degree > pol2.Degree)
            {
                Polynomial donePol = OperatorSubtractionHelper(pol1, pol2);
                return donePol;
            }
            else if (pol2.Degree > pol1.Degree)
            {
                Polynomial donePol = OperatorSubtractionHelper(pol2, pol1);
                return donePol;
            }

            return null;
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="pol1">The pol1.</param>
        /// <param name="pol2">The pol2.</param>
        /// <returns>
        /// The result of the operator *.
        /// </returns>
        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            double[] doneCoefs = new double[(pol1.Degree * pol2.Degree) + 1];
            for (int i = 0; i <= pol1.Degree; i++)
            {
                for (int j = 0; j <= pol2.Degree; j++)
                {
                    doneCoefs[i + j] += pol1.Coefs[i] * pol2.Coefs[j];
                }
            }

            Polynomial donePol = new Polynomial(doneCoefs);
            return donePol;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="pol1">The pol1.</param>
        /// <param name="pol2">The pol2.</param>
        /// <returns>
        /// The result of the operator !=.
        /// </returns>
        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            if (pol1.Degree == pol2.Degree)
            {
                for (int i = 0; i <= pol1.Degree; i++)
                {
                    if (pol1.Coefs[i] != pol2.Coefs[i])
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="pol1">The pol1.</param>
        /// <param name="pol2">The pol2.</param>
        /// <returns>
        /// The result of the operator ==.
        /// </returns>
        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (pol1.Degree == pol2.Degree)
            {
                for (int i = 0; i <= pol1.Degree; i++)
                {
                    if (pol1.Coefs[i] != pol2.Coefs[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="polynomial">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object polynomial)
        {
            if (polynomial != null)
            {
                Polynomial pol = polynomial as Polynomial;
                return this == pol;
            }

            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance
        /// </returns>
        public override int GetHashCode()
        {
            if (Coefs != null)
            {
                return Coefs.GetHashCode();
            }

            return 0;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string polynomyal = $"{Coefs[0]}x^{Degree}";
            for (int i = 1; i < Degree - 1; i++)
            {
                if (Coefs[i] != 0.0)
                {
                    polynomyal += $" + {Coefs[i]}x^{Degree - i}";
                }
            }

            if (Coefs[Degree - 1] != 0.0)
            {
                polynomyal += $" + {Coefs[Degree - 1]}x";
            }

            if (Coefs[Degree] != 0.0)
            {
                polynomyal += $" + {Coefs[Degree]}";
            }

            polynomyal += " = 0";
            return polynomyal;
        }

        #endregion
        #region private API        
        /// <summary>
        /// If degries aren't equale, compute addition
        /// </summary>
        /// <param name="pol1">The pol1.</param>
        /// <param name="pol2">The pol2.</param>
        /// <returns> Done Polynomial </returns>
        private static Polynomial OperatorPlusHelper(Polynomial pol1, Polynomial pol2)
        {
            double[] doneCoefs = new double[pol1.Degree + 1];
            for (int j = 0; j < pol1.Degree - pol2.Degree; j++)
            {
                doneCoefs[j] = pol1.Coefs[j];
            }

            for (int i = pol1.Degree - pol2.Degree; i <= pol1.Degree; i++)
            {
                doneCoefs[i] = pol1.Coefs[i] + pol2.Coefs[i - pol1.Degree + pol2.Degree];
            }

            Polynomial donePol = new Polynomial(doneCoefs);
            return donePol;
        }

        /// <summary>
        /// If degries aren't equale, compute subtraction
        /// </summary>
        /// <param name="pol1">The pol1.</param>
        /// <param name="pol2">The pol2.</param>
        /// <returns> Done Polynomial </returns>
        private static Polynomial OperatorSubtractionHelper(Polynomial pol1, Polynomial pol2)
        {
            double[] doneCoefs = new double[pol1.Degree + 1];
            for (int j = 0; j < pol1.Degree - pol2.Degree; j++)
            {
                doneCoefs[j] = pol1.Coefs[j];
            }

            for (int i = pol1.Degree - pol2.Degree; i <= pol1.Degree; i++)
            {
                doneCoefs[i] = pol1.Coefs[i] - pol2.Coefs[i - pol1.Degree + pol2.Degree];
            }

            Polynomial donePol = new Polynomial(doneCoefs);
            return donePol;
        }
        #endregion        
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="coefs"> Array of terms equation </param>
        /// <exception cref="System.ArgumentNullException"> Array of terms equation</exception>
        private void IsValid(double[] coefs)
        {
            if (coefs == null || coefs.Length == 0)
            {
                throw new ArgumentNullException(nameof(coefs));
            }
        }
    }
}