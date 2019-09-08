using System;
using System.Collections.Generic;

namespace Day13Lib.Matrix
{
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

        public void SymmetricalChange(int i, int j, T item)
        {
            CheckArguments(i, j);

            OnMatrixChanged($"In the symmetrical matrix, the element [{i}, {j}] ({matrix[i, j]}) and [{j}, {i}] ({matrix[j, i]}) was changed to {item.ToString()}");

            matrix[j, i] = item;
            matrix[i, j] = item;
        }
    }
}
