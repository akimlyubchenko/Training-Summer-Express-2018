using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseMatrix.SymmetricMatrix
{
    /// <summary>
    /// SymmetricMatrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BaseMatrix.BaseMatrix{T}" />
    public class SymmetricMatrix<T> : BaseMatrix<T>
    {
        private T[][] matrix;
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public SymmetricMatrix(T[][] matrix) : base(matrix) { }

        /// <summary>
        /// Ifs the symmetric matrix => true
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>true or false</returns>
        public static bool IfSymmetricMatrix(T[][] matrix)
        {
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!matrix[i][j].Equals(matrix[j][i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
