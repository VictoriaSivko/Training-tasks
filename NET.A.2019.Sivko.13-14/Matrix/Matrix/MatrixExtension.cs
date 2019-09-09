using System;

namespace Day13Lib.Matrix
{
    /// <summary>
    /// Represents arithmetic operations for matrices
    /// </summary>
    /// <typeparam name="T">Type of data stored in the matrix.</typeparam>
    public static class MatrixExtension<T>
    {
        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="matr1">The first matrix.</param>
        /// <param name="matr2">The second matrix</param>
        /// <param name="operation">The algorithm of matrix addition.</param>
        /// <returns>Square matrix.</returns>
        public static SquareMatrix<T> Add(Matrix<T> matr1, Matrix<T> matr2, Func<T, T, T> operation)
        {
            int size = matr1.Lenght > matr2.Lenght ? matr1.Lenght : matr2.Lenght;
            SquareMatrix<T> temp = new SquareMatrix<T>(size);

            if (matr1 == null || matr2 == null)
                throw new ArgumentNullException(matr1 == null ? matr1.ToString() : matr2.ToString());

            if (matr1.Lenght != matr2.Lenght)
                throw new Exception("Cannot add matrices of different dimensions.");

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    temp.SetElement(i, j, operation(matr1.GetElement(i, j), matr2.GetElement(i, j)));

            return temp;
        }
    }
}
