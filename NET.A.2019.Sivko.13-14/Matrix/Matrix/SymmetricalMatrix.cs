using System;
using System.Collections.Generic;

namespace Day13Lib.Matrix
{
    /// <summary>
    /// Implements a symmetrical matrix.
    /// </summary>
    /// <typeparam name="T">Type of data stored in the matrix.</typeparam>
    public class SymmetricalMatrix<T> : Matrix<T>
    {
        public SymmetricalMatrix(int size) : base(size) { }

        public override T GetElement(int i, int j)
        {
            CheckArguments(i, j);

            return matrix[i, j];
        }

        public override void SetElement(int i, int j, T item)
        {
            CheckArguments(i, j);

            IComparer<T> comparer = Comparer<T>.Default;

            if (i != j && comparer.Compare(item, matrix[j,i]) != 0)
                throw new Exception("An attempt to break the symmetry of the matrix");

            OnMatrixChanged($"In the symmetrical matrix, the element [{i}, {j}]({matrix[i, j]}) was changed to {item.ToString()}");

            matrix[i, j] = item;
        }

        /// <summary>
        /// Modifies two elements of the matrix to preserve the symmetry.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="item"></param>
        public void SymmetricalChange(int i, int j, T item)
        {
            CheckArguments(i, j);

            OnMatrixChanged($"In the symmetrical matrix, the element [{i}, {j}] ({matrix[i, j]}) and [{j}, {i}] ({matrix[j, i]}) was changed to {item.ToString()}");

            matrix[j, i] = item;
            matrix[i, j] = item;
        }
    }
}
