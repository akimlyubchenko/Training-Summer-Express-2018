using System;
using System.Collections.Generic;
namespace BaseMatrix
{
    /// <summary>
    /// Repositiory of simple matrix and some instructions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseMatrix<T>
    {
        private T[][] matrix;
        IComparer<T> comp;
        public delegate void ChangeNotifier(T[][] matrix);
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="comp">The comparer.</param>
        public BaseMatrix(T[][] matrix, IComparer<T> comp = null)
        {
            if (comp == null)
            {
                this.comp = Comparer<T>.Default;
            }

            this.matrix = matrix;
        }

        /// <summary>
        /// Creates the matrixes
        /// </summary>
        /// <param name="matrix">The matrix in array</param>
        /// <returns>Done matrix</returns>
        public static BaseMatrix<T> CreateMatrix(T[][] matrix)
        {
            Validator(matrix);
            if (DiagonalMatrix.DiagonalMatrix<T>.IfDiagonalMatrix(matrix))
            {
                return new DiagonalMatrix.DiagonalMatrix<T>(matrix);
            }

            if (SymmetricMatrix.SymmetricMatrix<T>.IfSymmetricMatrix(matrix))
            {
                return new SymmetricMatrix.SymmetricMatrix<T>(matrix);
            }

            if (SquareMatrix.SquareMatrix<T>.IfSquareMatrix(matrix))
            {
                return new SquareMatrix.SquareMatrix<T>(matrix);
            }

            return new BaseMatrix<T>(matrix);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        /// <exception cref="System.ArgumentException">Different matrix's range</exception>
        public static BaseMatrix<T> operator +(BaseMatrix<T> lhs, BaseMatrix<T> rhs)
        {
            if (lhs.matrix.Length != rhs.matrix.Length)
            {
                throw new ArgumentException("Different matrix's range");
            }

            T[][] temp = CreateEmptyMatrix(lhs.matrix.Length, lhs.matrix[0].Length);
            for (int i = 0; i < lhs.matrix.Length; i++)
            {
                for (int j = 0; j < lhs.matrix[0].Length; j++)
                {
                    temp[i][j] = (dynamic)lhs.matrix[i][j] + (dynamic)rhs.matrix[i][j];
                }
            }

            return CreateMatrix(temp);
        }

        /// <summary>
        /// Matrixes the comparer.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>true or false </returns>
        public static bool MatrixComparer(BaseMatrix<T> lhs, BaseMatrix<T> rhs)
        {
            for (int i = 0; i < lhs.matrix.Length; i++)
            {
                for (int j = 0; j < lhs.matrix[0].Length; j++)
                {
                    if (!lhs.matrix[i][j].Equals(rhs.matrix[i][j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void Validator(T[][] matrix)
        {
            if (matrix == null || matrix[0].Length == 0)
            {
                throw new ArgumentException("Invalid matrix");
            }

            for (int i = 0; i < matrix[i].Length - 1; i++)
            {
                if (matrix[i].Length != matrix[i + 1].Length)
                {
                    throw new ArgumentException("invalid matrix");
                }
            }
        }

        private static T[][] CreateEmptyMatrix(int i, int j)
        {
            T[][] temp = new T[i][];
            for (int n = 0; n < i; n++)
            {
                temp[n] = new T[j];
            }

            return temp;
        }
    }
}
