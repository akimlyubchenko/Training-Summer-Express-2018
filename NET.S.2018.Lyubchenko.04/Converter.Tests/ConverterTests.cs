using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Converter.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void IEEEConverter_34Point45_34()
        {
            string expected = "0100000001110000000001000001010001111010111000010100011110101110";
            double number = 256.255;

            string  actual =  Converter.IEEEConverter(number);
            Assert.AreEqual(expected, actual);

            // Эта единица все время вылазит!!! Мозг уже не работает,доделаю завтра 
            // Expected:< 0100000001110000000001000001010001111010111000010100011110101110 >.
            //   Actual:< 0100000001111000000000100000101000111101011100001010001111010111 >.

        }
    }
}
