using System;
using System.Collections.Generic;
using System.Text;

namespace NET.A._2019.Sivko._04
{
    public static class DoubleExtension
    {
        public static string BinaryDouble(this double original)
        {
            StringBuilder stringBuilder = new StringBuilder();

            //Бесконечности представлены как числа с порядком E=Emax+1 и нулевой мантиссой.
            //В IEEE754 NaN представлен как число, в котором E=Emax+1, а мантисса не нулевая.
            if (1 / original > 0)
                stringBuilder.Append("0");
            else
                stringBuilder.Append("1");

            //ищем Е 11 бит

            double E = 1;

            while (Math.Abs(original) >= Math.Pow(2, E))
                E++;

            E = E - 1 + 1023;

            stringBuilder.Append(Convert_Exponent_ToBitsString(E));

            stringBuilder.Append(Convert_Mantissa_ToBitsString(original));

            return stringBuilder.ToString();
        }

        private static StringBuilder Convert_Exponent_ToBitsString(double original)
        {
            byte[] array = new byte[11];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToByte(original % 2);
                original = Math.Truncate(original / 2);
            }

            return ConvertByteArrayToString(array);
        }

        private static StringBuilder ConvertByteArrayToString(byte[] bitArray)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = bitArray.Length - 1; i >= 0; i--)
                stringBuilder.Append(bitArray[i]);
            return stringBuilder;
        }

        private static StringBuilder Convert_Mantissa_ToBitsString(double original)
        {
            if (original == -0.0 || original == +0.0)
                return ConvertByteArrayToString(new byte[52]);

            List<byte> bitList = new List<byte>();
            double temp = original;
            //целая часть
            while (temp > 0)
            {
                bitList.Add(Convert.ToByte(original % 2));
                temp = Math.Truncate(temp / 2);
            }
            //дробная часть


            return new StringBuilder();
        }
    }
}
