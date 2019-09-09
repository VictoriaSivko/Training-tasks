using System;

namespace Day13Lib.Matrix
{
    /// <summary>
    /// Implements a square matrix.
    /// </summary>
    /// <typeparam name="T">Type of data stored in the matrix.</typeparam>
    public class SquareMatrix<T>: Matrix<T>
    {
        public SquareMatrix(int size) : base(size) { }

        public override T GetElement(int i, int j)
        {
            CheckArguments(i, j);

            return matrix[i, j];
        }

        public override void SetElement(int i, int j, T item)
        {
            CheckArguments(i, j);

            OnMatrixChanged($"In the square matrix, the element [{i}, {j}]({matrix[i, j]}) was changed to {item.ToString()}");

            matrix[i, j] = item;
        }
    }
}
