using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseMatrix.DiagonalMatrix
{
    /// <summary>
    /// DiagonalMatrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BaseMatrix.BaseMatrix{T}" />
    public class DiagonalMatrix<T> : BaseMatrix<T>
    {
        private T[][] matrix;
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public DiagonalMatrix(T[][] matrix) : base(matrix) { }

        /// <summary>
        /// Ifs the diagonal matrix => true
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>true or false</returns>
        public static bool IfDiagonalMatrix(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (!matrix[i][j].Equals(default(T)))
                    {
                        if (j != i)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
