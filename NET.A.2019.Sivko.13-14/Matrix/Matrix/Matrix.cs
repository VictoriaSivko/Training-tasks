using System;
using System.Collections;
using System.Collections.Generic;

namespace Day13Lib.Matrix
{
    public abstract class Matrix<T> : IEnumerable<T>
    {
        protected T[,] matrix;
        public int Lenght { get; private set; } 

        protected delegate void MatrixInfo(string s);
        protected event MatrixInfo ChangeMatrix;

        public Matrix(int size)
        {
            if (size <= 0)
                throw new Exception("Cannot create a negative dimension matrix");

            Lenght = size;
            matrix = new T[size, size];
        }

        protected void CheckArguments(int i, int j)
        {
            if (i > matrix.GetLength(0) || j > matrix.GetLength(1) || i < 0 || j < 0)
                throw new ArgumentException("Argument out of range");
        }

        public abstract T GetElement(int i, int j);
        public abstract void SetElement(int i, int j, T item);

        protected void OnMatrixChanged(string s)
        {
            if (ChangeMatrix != null)
                ChangeMatrix(s);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    yield return matrix[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
