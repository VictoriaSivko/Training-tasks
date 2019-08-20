using System;

namespace NET.A._2019.Sivko._06
{
    /// <summary>
    /// The Polynomial class is used to work with polynomials
    /// </summary>
    public sealed class Polynomial
    {
        private readonly double[] coefficient;

        /// <summary>
        /// The constructor initializes a readonly field of the Polynomial class
        /// </summary>
        /// <param name="coeff">The array of coefficients of the polynomial</param>
        public Polynomial(double[] coeff)
        {
            if(coeff == null || coeff.Length == 0)
                throw new ArgumentNullException("Received a null array");

            coefficient = coeff;
        }

        /// <summary>
        /// The ToString method returns a string representation of a polynomial
        /// </summary>
        /// <returns>The string representation of a polynomial</returns>
        public override string ToString()
        {
            string temp = coefficient[0] + "";

            for (int i = 1; i < coefficient.Length; i++)
            {
                if (1 / coefficient[i] > 0)
                    temp += " + ";
                else
                {
                    temp += " - ";
                    coefficient[i] *= -1;
                }

                temp += coefficient[i] + "*(x^" + i + ")";
            }

            return temp;
        }

        /// <summary>
        /// The Equals method compares objects
        /// </summary>
        /// <returns>Returns true if the objects are the same and false otherwise</returns>
        public override bool Equals(object obj)
        {
            if(obj is Polynomial)
            {
                Polynomial p = obj as Polynomial; 

                if (p.GetHashCode() == GetHashCode())
                {
                    for(int i = 0; i<coefficient.Length; i++)
                    {
                        if (p.coefficient[i] != coefficient[i])
                            return false;
                    }
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Finds the hash of a polynomial by a special algorithm
        /// </summary>
        /// <returns>Hash code of the polynomial</returns>
        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < coefficient.Length; i++)
                hash += Convert.ToInt32(coefficient[i] * 19);

            return hash;
        }

        /// <summary>
        /// This method compares Polynomial objects
        /// </summary>
        /// <param name="p1">First Polynomial object</param>
        /// <param name="p2">Second Polynomial object</param>
        /// <returns>Returns true if the objects are the same and false otherwise</returns>
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (p1.Equals(p2))
                return true;
            else
                return false;
        }

        /// <summary>
        /// This method compares Polynomial objects
        /// </summary>
        /// <param name="p1">First Polynomial object</param>
        /// <param name="p2">Second Polynomial object</param>
        /// <returns>Returns false if the objects are the same and true otherwise</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            if (p1.Equals(p2))
                return false;
            else
                return true;
        }

        /// <summary>
        /// This method compares a polynomial to an object
        /// </summary>
        /// <param name="p1">Polynomial</param>
        /// <param name="obj">Object</param>
        /// <returns>Returns true if the objects are the same and false otherwise</returns>
        public static bool operator ==(Polynomial p1, object obj)
        {
            if (obj is Polynomial)
                if (p1.Equals(obj))
                    return true;
            return false;
        }

        /// <summary>
        /// This method compares a polynomial to an object
        /// </summary>
        /// <param name="p1">Polynomial</param>
        /// <param name="obj">Object</param>
        /// <returns>Returns false if the objects are the same and true otherwise</returns>
        public static bool operator !=(Polynomial p1, object obj)
        {
            if (obj is Polynomial)
                if (p1.Equals(obj))
                    return false;
            return true;
        }

        /// <summary>
        /// This method sums two polynomials
        /// </summary>
        /// <param name="p1">First Polynomial object</param>
        /// <param name="p2">Second Polynomial object</param>
        /// <returns>New Polynomial object</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            int max = Math.Max(p1.coefficient.Length, p2.coefficient.Length);

            double[] sum = new double[max];

            for (int i = 0; i < p1.coefficient.Length; i++)
                sum[i] = p1.coefficient[i];

            for (int i = 0; i < p2.coefficient.Length; i++)
                sum[i] += p2.coefficient[i];

            return new Polynomial(sum);
        }

        /// <summary>
        /// This method sums a polynomial with a number
        /// </summary>
        /// <param name="p1">Polynomial</param>
        /// <param name="obj">Object</param>
        /// <returns>New Polynomial object</returns>
        public static Polynomial operator +(Polynomial p1, object obj)
        {
            if (!IsNumber(obj))
                throw new Exception("The second parameter is not a number");
            
            double[] sum = new double[p1.coefficient.Length];

            obj = Convert.ToDouble(obj);

            for (int i = 0; i < p1.coefficient.Length; i++)
                sum[i] = p1.coefficient[i] + (double)obj;

            return new Polynomial(sum);
        }

        /// <summary>
        /// Unary + operator
        /// </summary>
        /// <param name="p1">Polynomial object</param>
        /// <returns>The passed polynomial</returns>
        public static Polynomial operator +(Polynomial p1)
        {
            return p1;
        }

        /// <summary>
        /// This method finds the difference of two polynomials
        /// </summary>
        /// <param name="p1">First Polynomial object</param>
        /// <param name="p2">Second Polynomial object</param>
        /// <returns>New Polynomial object</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            int max = Math.Max(p1.coefficient.Length, p2.coefficient.Length);

            double[] sum = new double[max];

            for (int i = 0; i < p1.coefficient.Length; i++)
                sum[i] = p1.coefficient[i];

            for (int i = 0; i < p2.coefficient.Length; i++)
                sum[i] -= p2.coefficient[i];

            return new Polynomial(sum);
        }

        /// <summary>
        /// This method subtracts a number from the polynomial
        /// </summary>
        /// <param name="p1">Polynomial</param>
        /// <param name="obj">Object</param>
        /// <returns>New Polynomial object</returns>
        public static Polynomial operator -(Polynomial p1, object obj)
        {
            if (!IsNumber(obj))
                throw new Exception("The second parameter is not a number");

            double[] sum = new double[p1.coefficient.Length];

            obj = Convert.ToDouble(obj);

            for (int i = 0; i < p1.coefficient.Length; i++)
                sum[i] = p1.coefficient[i] - (double)obj;

            return new Polynomial(sum);
        }

        /// <summary>
        /// Unary + operator
        /// </summary>
        /// <param name="p1">Polynomial object</param>
        /// <returns>Polynomial with coefficients that have changed their sign</returns>
        public static Polynomial operator -(Polynomial p1)
        {
            for(int i = 0; i < p1.coefficient.Length; i++)
                p1.coefficient[i] = -p1.coefficient[i];

            return p1;
        }

        /// <summary>
        /// This method multiplies one polynomial by another polynomial
        /// </summary>
        /// <param name="p1">First Polynomial object</param>
        /// <param name="p2">Second Polynomial object</param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            double[] result = new double[p1.coefficient.Length + p2.coefficient.Length];

            for (int i = 0; i < p1.coefficient.Length; i++)
            {
                for (int j = 0; j < p2.coefficient.Length; j++)
                {
                    result[i + j] += (p1.coefficient[i] * p2.coefficient[j]);
                }
            }
            return new Polynomial(result);
        }

        /// <summary>
        /// This method multiplies the polynomial by a number
        /// </summary>
        /// <param name="p1">Polynomial</param>
        /// <param name="obj">Object</param>
        /// <returns>New Polynomial object</returns>
        public static Polynomial operator *(Polynomial p1, object obj)
        {
            if (!IsNumber(obj))
                throw new Exception("The second parameter is not a number");

            double[] result = new double[p1.coefficient.Length];

            obj = Convert.ToDouble(obj);

            for (int i = 0; i < p1.coefficient.Length; i++)
                result[i] = p1.coefficient[i] * (double)obj;

            return new Polynomial(result);
        }

        /// <summary>
        /// This method divides a polynomial by a number
        /// </summary>
        /// <param name="p1">Polynomial</param>
        /// <param name="obj">Object</param>
        /// <returns>New Polynomial object</returns>
        public static Polynomial operator /(Polynomial p1, object obj)
        {
            if (!IsNumber(obj))
                throw new Exception("The second parameter is not a number");

            obj = Convert.ToDouble(obj);

            if ((double)obj == 0)
                throw new ArgumentNullException("Division by zero is prohibited");

            double[] result = new double[p1.coefficient.Length];

            for (int i = 0; i < p1.coefficient.Length; i++)
                result[i] = p1.coefficient[i] / (double)obj;

            return new Polynomial(result);
        }

        /// <summary>
        /// The IsNumber method determines whether the object is a number
        /// </summary>
        /// <param name="value">Object</param>
        /// <returns>Returns true if the object is a number and false otherwise</returns>
        private static bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
}
