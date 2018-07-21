using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCD.Tests
{
    [TestClass]
    public class GCDTests
    {
        [TestMethod]
        public void GetGCD_800And225_25()
        {
            // Arr
            int v1 = 800, v2 = 225;
            int expected = 25;

            // Act
            int actual = GCD.GetGCD(v1, v2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_0And25_25()
        {
            // Arr
            int v1 = 0, v2 = 25;
            int expected = 25;

            // Act
            int actual = GCD.GetGCD(v1, v2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_40And0_40()
        {
            // Arr
            int v1 = 40, v2 = 0;
            int expected = 40;

            // Act
            int actual = GCD.GetGCD(v1, v2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_1000And225_100()
        {
            // Arr
            int v1 = 1000, v2 = 100;
            int expected = 100;

            // Act
            int actual = GCD.GetGCD(v1, v2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_750And250_250()
        {
            // Arr
            int v1 = 750, v2 = 250;
            int expected = 250;

            // Act
            int actual = GCD.GetGCD(v1, v2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_345720AndNegative250_2345()
        {
            // Arr
            int v1 = 345720, v2 = -2345;
            int expected = 335;

            // Act
            int actual = GCD.GetGCD(v1, v2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_6And9And15_3()
        {
            // Arr
            int v1 = 6, v2 = 9, v3 = 15;
            int expected = 3;

            // Act
            int actual = GCD.GetGCD(v1, v2, v3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_64And32And128_32()
        {
            // Arr
            int v1 = 64, v2 = 32, v3 = 128;
            int expected = 32;

            // Act
            int actual = GCD.GetGCD(v1, v2, v3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_64And32And128AndNegative30And12And8_2()
        {
            // Arr
            int v1 = 64, v2 = 32, v3 = 128, v4 = -30, v5 = 12, v6 = 8;
            int expected = 2;

            // Act
            int actual = GCD.GetGCD(v1, v2, v3, v4, v5, v6);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGCD_5_Exception()
            => GCD.GetGCD(5);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGCD_Empty_Exception()
            => GCD.GetGCD();

        [TestMethod]
        public void GetGCD_64And32And0_32()
        {
            // Arr
            int v1 = 64, v2 = 32, v3 = 0;
            int expected = 32;

            // Act
            int actual = GCD.GetGCD(v1, v2, v3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_64And32And1_32()
        {
            // Arr
            int v1 = 64, v2 = 32, v3 = 128;
            int expected = 32;

            // Act
            int actual = GCD.GetGCD(v1, v2, v3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCD_11And56And12346_1()
        {
            // Arr
            int v1 = 11, v2 = 56, v3 = 12346;
            int expected = 1;

            // Act
            int actual = GCD.GetGCD(v1, v2, v3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSteinGCD_10And5_5()
        {
            // Arr
            int v1 = 10, v2 = 5;
            int expected = 5;

            // Act
            int actual = GCD.GetGCD(v1, v2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSteinGCD_16And20_4()
        {
            // Arr
            int v1 = 16, v2 = 20;
            int expected = 4;

            // Act
            int actual = GCD.GetGCD(v1, v2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSteinGCD_16And5And1234_1()
        {
            // Arr
            int v1 = 16, v2 = 5, v3 = 1234;
            int expected = 1;

            // Act
            int actual = GCD.GetGCD(v1, v2, v3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSteinGCD_16And2000And1234_1()
        {
            // Arr
            int v1 = 16, v2 = 2000, v3 = 1234;
            int expected = 2;

            // Act
            int actual = GCD.GetGCD(v1, v2, v3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSteinGCD_16And0And1234_1()
        {
            // Arr
            int v1 = 16, v2 = 0, v3 = 1234;
            int expected = 2;

            // Act
            int actual = GCD.GetGCD(v1, v2, v3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetSteinGCD_5_Exception()
            => GCD.GetGCD(5);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetSteinGCD_Empty_Exception()
            => GCD.GetGCD();

        [TestMethod]
        public void GetGCDWidthTime_1264_2()
        {
            int v1 = 12, v2 = 6, v3 = 4;
            int expected = 2;

            (int actual, TimeSpan time) = GCD.GetGCDWidthTime(v1, v2, v3);
            Debug.WriteLine($"Time: {time.Seconds}:{time.Ticks}");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGCDDelegate_16And5_1()
        {
            // Arr
            int v1 = 20, v2 = 5;
            int expected = 5;

            // Act
            Func<int, int, int> GCDDelegate = new Func<int, int, int>(GCD.GetGCD);
            int actual = GCDDelegate.Invoke(v1, v2); ;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSteinGCDDelegate_16And5_1()
        {
            // Arr
            int v1 = 20, v2 = 5;
            int expected = 5;

            // Act
            Func<int, int, int> GCDDelegate = new Func<int, int, int>(GCD.GetSteinGCD);
            int actual = GCDDelegate.Invoke(v1, v2); ;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
