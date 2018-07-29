using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseMatrix.SquareMatrix;
using BaseMatrix.DiagonalMatrix;
using BaseMatrix.SymmetricMatrix;

namespace BaseMatrix.Tests
{
    [TestClass]
    public class BaseMatrixTests
    {
        [TestMethod]
        public void BaseMatrix_SimpleMatrix()
        {
            int[][] m = new int[][]
                            {
                            new int[]{1,0,2},
                            new int[]{1,1,0},
                            new int[]{2,0,1},
                            new int[]{14,3,2}
                            };

            BaseMatrix<int> matrix1 = BaseMatrix<int>.CreateMatrix(m);

            Assert.AreEqual(typeof(BaseMatrix<int>), matrix1.GetType());
        }

        [TestMethod]
        public void BaseMatrix_SquareMatrix()
        {
            int[][] m = new int[][]
                            {
                            new int[]{1,0,2},
                            new int[]{1,1,0},
                            new int[]{2,0,1},
                            };

            BaseMatrix<int> matrix1 = BaseMatrix<int>.CreateMatrix(m);

            Assert.AreEqual(typeof(SquareMatrix<int>), matrix1.GetType());
        }

        [TestMethod]
        public void BaseMatrix_SymmetricMatrix()
        {
            int[][] m = new int[][]
                            {
                            new int[]{1,0,2},
                            new int[]{0,1,0},
                            new int[]{2,0,1},
                            };

            BaseMatrix<int> matrix1 = BaseMatrix<int>.CreateMatrix(m);

            Assert.AreEqual(typeof(SymmetricMatrix<int>), matrix1.GetType());
        }

        [TestMethod]
        public void BaseMatrix_DiagonalMatrix()
        {
            int[][] m = new int[][]
                            {
                            new int[]{1,0,0},
                            new int[]{0,1,0},
                            new int[]{0,0,1},
                            };

            BaseMatrix<int> matrix1 = BaseMatrix<int>.CreateMatrix(m);

            Assert.AreEqual(typeof(DiagonalMatrix<int>), matrix1.GetType());
        }

        [TestMethod]
        public void BaseMatrix_SumMatrix()
        {
            int[][] m = new int[][]
                            {
                            new int[]{1,0,4},
                            new int[]{0,1,0},
                            new int[]{4,0,1},
                            };

            BaseMatrix<int> matrix1 = BaseMatrix<int>.CreateMatrix(m);

            int[][] m2 = new int[][]
                                {
                                new int[]{1,0,2},
                                new int[]{3,1,3},
                                new int[]{2,0,1}
                                };
            BaseMatrix<int> matrix2 = BaseMatrix<int>.CreateMatrix(m2);

            BaseMatrix<int> matrix3 = matrix1 + matrix2;
            int[][] m3 = new int[][]
                            {
                            new int[]{2,0,6},
                            new int[]{3,2,3},
                            new int[]{6,0,2},
                            };

            BaseMatrix<int> expected = BaseMatrix<int>.CreateMatrix(m3);

            Assert.IsFalse(!BaseMatrix<int>.MatrixComparer(matrix3,expected));
        }
    }
}
