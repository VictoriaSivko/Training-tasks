using System;
using System.Collections;
using System.Collections.Generic;

namespace Day13Lib.Matrix
{
    /// <summary>
    /// Represents the matrix.
    /// </summary>
    /// <typeparam name="T">Type of data stored in the matrix.</typeparam>
    public abstract class Matrix<T> : IEnumerable<T>
    {
        protected T[,] matrix;

        /// <summary>
        /// Length of the matrix.
        /// </summary>
        public int Lenght { get; private set; } 

        protected delegate void MatrixInfo(string s);
        protected event MatrixInfo ChangeMatrix;

        /// <summary>
        /// Initializes the matrix object.
        /// </summary>
        /// <param name="size"></param>
        public Matrix(int size)
        {
            if (size <= 0)
                throw new Exception("Cannot create a negative dimension matrix");

            Lenght = size;
            matrix = new T[size, size];
        }

        /// <summary>
        /// Checks the index of the element.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        protected void CheckArguments(int i, int j)
        {
            if (i > matrix.GetLength(0) || j > matrix.GetLength(1) || i < 0 || j < 0)
                throw new ArgumentException("Argument out of range");
        }

        /// <summary>
        /// Returns the matrix element.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        /// <returns>Queue element.</returns>
        public abstract T GetElement(int i, int j);

        /// <summary>
        /// Changes the matrix element.
        /// </summary>
        /// <param name="i">First index.</param>
        /// <param name="j">Second index.</param>
        /// <param name="item">Data.</param>
        public abstract void SetElement(int i, int j, T item);

        /// <summary>
        /// Raises the element change event.
        /// </summary>
        /// <param name="s">information line.</param>
        protected void OnMatrixChanged(string s)
        {
            if (ChangeMatrix != null)
                ChangeMatrix(s);
        }

        /// <summary>
        /// Iterates through the objects of the class.
        /// </summary>
        /// <returns></returns>
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
