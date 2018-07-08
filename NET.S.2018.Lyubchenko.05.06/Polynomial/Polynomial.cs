using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynomial
    {
        private double[] Coefs { get; set; }
        private int Degree { get; set; }

        public Polynomial(double[] coefs)
        {
            IsValid(coefs);
            Coefs = coefs;
            Degree = Coefs.Length - 1;
        }

        public override bool Equals(object polynomial)
        {
            if (polynomial != null)
            {
                Polynomial pol = polynomial as Polynomial;
                return this == pol;
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Coefs != null)
            {
                return Coefs.GetHashCode();
            }

            return 0;
        }

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

        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            double[] doneCoefs = new double[pol1.Degree * pol2.Degree + 1];
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


        private void IsValid(double[] coefs)
        {
            if (coefs == null || coefs.Length == 0)
            {
                throw new ArgumentNullException(nameof(coefs));
            }
        }
    }
}