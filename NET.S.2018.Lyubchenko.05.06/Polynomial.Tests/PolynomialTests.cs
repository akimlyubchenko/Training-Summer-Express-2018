using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Polynomial.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(1, 2, 3, ExpectedResult = "1x^2 + 2x + 3 = 0")]
        [TestCase(34.34, 21.42, 0, 1, ExpectedResult = "34,34x^3 + 21,42x^2 + 1 = 0")]
        [TestCase(1, 123.3, 0, ExpectedResult = "1x^2 + 123,3x = 0")]
        public string ToString_DoubleArray_ValidResult(params double[] coefs)
        {
            Polynomial pol = new Polynomial(coefs);
            return pol.ToString();
        }


        [TestCase(1, 2, 3, ExpectedResult = 55467396)]

        [Test]
        public int HashCode_DoubleArray_ValidResult(params double[] coefs)
        {
            Polynomial pol = new Polynomial(coefs);
            return pol.GetHashCode();
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 2, 4, 6 }, new double[] { 3, 6, 9 })]
        [TestCase(new double[] { 14.5, 0, -5.5 }, new double[] { 22.5, 4, -4.5 }, new double[] { 37, 4, -10 })]
        public void Addition_DoubleArrays_ValidAddition(double[] coefs1, double[] coefs2, double[] coefsex)
        {
            Polynomial pol1 = new Polynomial(coefs1);
            Polynomial pol2 = new Polynomial(coefs2);
            Polynomial polex = new Polynomial(coefsex);

            Polynomial actual = pol1 + pol2;

            Assert.True(polex == actual);

        }

        [TestCase(new double[] { 3, 6, 9 }, new double[] { 1, 2, 3 }, new double[] { 2, 4, 6 })]
        [TestCase(new double[] { 37, 4, -10 }, new double[] { 14.5, 0, -5.5 }, new double[] { 22.5, 4, -4.5 })]
        public void Subtraction_DoubleArrays_ValidSubtraction(double[] coefs1, double[] coefs2, double[] coefsex)
        {
            Polynomial pol1 = new Polynomial(coefs1);
            Polynomial pol2 = new Polynomial(coefs2);
            Polynomial polex = new Polynomial(coefsex);

            Polynomial actual = pol1 - pol2;

            Assert.True(polex == actual);

        }

        [TestCase(new double[] { 3, 6, 9 }, new double[] { 1, 2, 3 }, new double[] { 3, 12, 30, 36, 27 })]
        [TestCase(new double[] { 37, 4, -10 }, new double[] { 14.5, 0, -5.5 }, new double[] { 536.5, 58, -348.5, -22, 55 })]
        public void Multiply_DoubleArrays_ValidMultiply(double[] coefs1, double[] coefs2, double[] coefsex)
        {
            Polynomial pol1 = new Polynomial(coefs1);
            Polynomial pol2 = new Polynomial(coefs2);
            Polynomial polex = new Polynomial(coefsex);

            Polynomial actual = pol1 * pol2;

            Assert.True(polex == actual);

        }

        [Test]
        public void ArgumentNullExceptionIfArrayEqualeNull() =>
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
    }
}
