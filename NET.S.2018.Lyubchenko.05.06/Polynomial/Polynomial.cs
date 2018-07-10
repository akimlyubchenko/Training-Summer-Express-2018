using System;
using System.Text;

namespace Polynomial
{
    /// <summary>
    /// Generate polynomial
    /// </summary>
    public class Polynomial : IEquatable<Polynomial>, ICloneable
    {
        private double[] coefs;
        public int Degree { get; private set; }
        #region public API        
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefs"> The numbers of equation </param>
        public Polynomial(double[] coefs)
        {
            Validator(coefs);
            this.coefs = coefs;
            Degree = coefs.Length - 1;
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index > Degree)
                {
                    throw new IndexOutOfRangeException($"{nameof(index)} must less as {Degree}");
                }

                return coefs[index];
            }

            private set
            {
                if (index < 0 || index > Degree)
                {
                    throw new IndexOutOfRangeException($"{nameof(index)} must less as {Degree}");
                }

                coefs[index] = value;
            }
        }
        #endregion
        #region Overrides        
        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs"> First polynom</param>
        /// <param name="rhs"> Second polynom</param>
        /// <returns>
        /// Sum 2 polynoms
        /// </returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            CheckInput(lhs, rhs);
            if (lhs.Degree == rhs.Degree)
            {
                double[] doneCoefs = new double[rhs.Degree + 1];
                for (int i = 0; i <= lhs.Degree; i++)
                {
                    doneCoefs[i] = lhs.coefs[i] + rhs.coefs[i];
                }

                return new Polynomial(doneCoefs);
            }
            else if (lhs.Degree > rhs.Degree)
            {
                return OperatorPlusHelper(lhs, rhs);
            }
            else if (rhs.Degree > lhs.Degree)
            {
                return OperatorPlusHelper(rhs, lhs);
            }

            return null;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs"> First polynom</param>
        /// <param name="rhs"> Second polynom</param>
        /// <returns>
        /// The result of the operator -.
        /// </returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            double[] tempCoefs = new double[rhs.coefs.Length];
            for (int i = 0; i < tempCoefs.Length; i++)
            {
                tempCoefs[i] = rhs.coefs[i] * (-1);
            }

            Polynomial tempPol = new Polynomial(tempCoefs);
            return lhs + tempPol;
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs"> First polynom</param>
        /// <param name="rhs"> Second polynom</param>
        /// <returns>
        /// The result of the operator *.
        /// </returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            double[] doneCoefs = new double[(lhs.Degree * rhs.Degree) + 1];
            for (int i = 0; i <= lhs.Degree; i++)
            {
                for (int j = 0; j <= rhs.Degree; j++)
                {
                    doneCoefs[i + j] += lhs.coefs[i] * rhs.coefs[j];
                }
            }

            return new Polynomial(doneCoefs);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="lhs"> First polynom</param>
        /// <param name="rhs"> Second polynom</param>
        /// <returns>
        /// The result of the operator !=.
        /// </returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            if (lhs == rhs)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="lhs"> First polynom</param>
        /// <param name="rhs"> Second polynom</param>
        /// <returns>
        /// The result of the operator ==.
        /// </returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if ((object)lhs == null)
            {
                return false;
            }

            if ((object)rhs == null)
            {
                return false;
            }

            if (lhs.Degree == rhs.Degree)
            {
                for (int i = 0; i <= lhs.Degree; i++)
                {
                    if (lhs.coefs[i] != rhs.coefs[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
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
            if (coefs != null)
            {
                return coefs.GetHashCode();
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
            StringBuilder polynomyal = new StringBuilder();
            int i = 0;
            do
            {
                if (coefs[i] != 0)
                {
                    polynomyal.Append($"{coefs[i]}x^{Degree}");
                    i++;
                    break;
                }
            } while (coefs[i] != 0);
            for (; i < Degree - 1; i++)
            {
                if (coefs[i] != 0.0)
                {
                    polynomyal.Append($" + {coefs[i]}x^{Degree - i}");
                }
            }

            if (coefs[Degree - 1] != 0.0)
            {
                polynomyal.Append($" + {coefs[Degree - 1]}x");
            }

            if (coefs[Degree] != 0.0)
            {
                polynomyal.Append($" + {coefs[Degree]}");
            }

            polynomyal.Append(" = 0");
            return polynomyal.ToString();
        }

        #endregion
        #region Interfases
        public object Clone()
        {
            double[] doneCoefs = new double[Degree + 1];
            for (int i = 0; i <= Degree; i++)
            {
                doneCoefs[i] = coefs[i];
            }

            return new Polynomial(doneCoefs);
        }

        public bool Equals(Polynomial other)
        {
            if (other.Degree != Degree)
            {
                return false;
            }

            for (int i = 0; i < other.coefs.Length; i++)
            {
                if (other.coefs[i] != coefs[i])
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
        #region private API        
        /// <summary>
        /// If degries aren't equale, compute addition
        /// </summary>
        /// <param name="lhs"> First polynom</param>
        /// <param name="rhs"> Second polynom</param>
        /// <returns> Done Polynomial </returns>
        private static Polynomial OperatorPlusHelper(Polynomial lhs, Polynomial rhs)
        {
            double[] doneCoefs = new double[lhs.Degree + 1];
            for (int j = 0; j < lhs.Degree - rhs.Degree; j++)
            {
                doneCoefs[j] = lhs.coefs[j];
            }

            for (int i = lhs.Degree - rhs.Degree; i <= lhs.Degree; i++)
            {
                doneCoefs[i] = lhs.coefs[i] + rhs.coefs[i - lhs.Degree + rhs.Degree];
            }

            return new Polynomial(doneCoefs);
        }

        #endregion        
       
        /// <summary>
        /// Checks the input object
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <exception cref="ArgumentNullException"> If obj == null </exception>
        /// <exception cref="ArgumentException"> If coefs.Lenght == 0 </exception>
        private static void CheckInput(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"{nameof(obj)} is null!");
            }

            Polynomial pol = obj as Polynomial;
            if (pol.coefs.Length == 0)
            {
                throw new ArgumentException($"{nameof(obj)} must have any coefficients!");
            }
        }

        /// <summary>
        /// Checks the input objects
        /// </summary>
        /// <param name="lhs">The fist obj.</param>
        /// <param name="rhs">The second obj.</param>
        private static void CheckInput(object lhs, object rhs)
        {
            CheckInput(lhs);
            CheckInput(rhs);
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="coefs"> Array of terms equation </param>
        /// <exception cref="System.ArgumentNullException"> Array of terms equation</exception>
        private void Validator(double[] coefs)
        {
            if (coefs == null || coefs.Length == 0)
            {
                throw new ArgumentNullException(nameof(coefs));
            }
        }
    }
}