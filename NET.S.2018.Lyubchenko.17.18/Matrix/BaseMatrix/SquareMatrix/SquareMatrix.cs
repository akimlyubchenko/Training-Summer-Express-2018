using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseMatrix.SquareMatrix
{
    /// <summary>
    /// SquareMatrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BaseMatrix.BaseMatrix{T}" />
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        private T[][] matrix;
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public SquareMatrix(T[][] matrix) : base(matrix) { }

        /// <summary>
        /// Ifs the square matrix => true
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        public static bool IfSquareMatrix(T[][] matrix)
        {
            if (matrix.Length != matrix[0].Length)
            {
                return false;
            }

            return true;
        }
    }
}
