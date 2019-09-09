using System;

namespace Day13Lib.Matrix
{
    /// <summary>
    /// Implements a diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Type of data stored in the matrix.</typeparam>
    public class DiagonalMatrixt<T> : Matrix<T>
    {
        public DiagonalMatrixt(int size) : base(size) { }

        public override T GetElement(int i, int j)
        {
            CheckArguments(i, j);

            return matrix[i, j];
        }

        public override void SetElement(int i, int j, T item)
        {
            CheckArguments(i, j);

            if (i != j)
                throw new Exception("Only diagonal elements of the matrix can be changed.");

            OnMatrixChanged($"In the diagonal matrix, the element [{i}, {j}]({matrix[i,j]}) was changed to {item.ToString()}");

            matrix[i, j] = item;
        }
    }
}
