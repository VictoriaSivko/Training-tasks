using System;

namespace Day13Lib.Matrix
{
    public static class MatrixExtension<T>
    {
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
