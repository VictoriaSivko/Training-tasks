using System;
using System.Collections.Generic;
using System.Text;

namespace NET.A._2019.Sivko._04
{
    /// <summary>
    /// The DoubleExtension class converts double into binary string
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Present double number in IEEE754 format.
        /// </summary>
        /// <param name="original">The real number to be converted</param>
        /// <returns>String representation of the Double in IEEE754 format</returns>
        public static string BinaryDouble(this double original)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (1 / original > 0 || double.IsPositiveInfinity(original))
                stringBuilder.Append("0");
            else
                stringBuilder.Append("1");

            //Infinity is represented as the number with the order E=Emax+1 and a zero mantissa
            if (double.IsInfinity(original))
            {
                stringBuilder.Append(Convert_Exponent_ToBitsString(2047)); //Emax
                return stringBuilder.Append(ConvertByteArrayToString(new byte[52])).ToString();
            }

            //In IEEE754, NaN is represented as a number in which E=Emax+1 and the mantissa is not zero
            if (double.IsNaN(original))
            {
                stringBuilder.Append(Convert_Exponent_ToBitsString(2047)); //Emax
                stringBuilder.Append(1);
                return stringBuilder.Append(ConvertByteArrayToString(new byte[51])).ToString();
            }

            if(original == double.Epsilon)
            {
                stringBuilder.Append(ConvertByteArrayToString(new byte[62]));
                return stringBuilder.Append(1).ToString();
            }

            if (original == -0.0 || original == +0.0)
                return stringBuilder.Append(ConvertByteArrayToString(new byte[63])).ToString();

            double E = 1;

            if (Math.Truncate(original) != 0)
            {
                while (Math.Abs(original) >= Math.Pow(2, E))
                    E++;

                E = E - 1 + 1023;
            }
            else
                E = 0;

            stringBuilder.Append(Convert_Exponent_ToBitsString(E));

            stringBuilder.Append(Convert_Mantissa_ToBitsString(Math.Abs(original)));

            return stringBuilder.ToString();
        }

        private static StringBuilder Convert_Exponent_ToBitsString(double original)
        {
            byte[] array = new byte[11];
            int i = 0;

            while(original>0)
            {
                array[i] = Convert.ToByte(original % 2);
                original = Math.Truncate(original / 2);
                i++;
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
            List<byte> bitList = new List<byte>();
            double temp = original;
            bool start = false;

            //integer part
            while (temp > 0)
            {
                bitList.Add(Convert.ToByte(temp % 2));
                temp = Math.Truncate(temp / 2);
            }

            bitList = RemoveFist1InMantissa(bitList, ref start);

            bitList.Reverse();

            //fractional part
            temp = original - Math.Truncate(original);
            while (bitList.Count != 52 && bitList.Count < 53)
            {
                if (start)
                {
                    temp *= 2;
                    bitList.Add(Convert.ToByte(Math.Truncate(temp)));
                    temp -= Math.Truncate(temp);
                }
                else
                {
                    temp *= 2;
                    if (Math.Truncate(temp) == 1)
                        start = true;
                    temp -= Math.Truncate(temp);
                }
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 52; i++)
                stringBuilder.Append(bitList[i]);

            return stringBuilder;
        }

        private static List<byte> RemoveFist1InMantissa(List<byte> bitList, ref bool start)
        {
            if (bitList.Contains(1))
                for (int i = bitList.Count - 1; i >= 0; i--)
                {
                    if (bitList[i] == 1)
                    {
                        bitList.RemoveAt(i);
                        start = true;
                        break;
                    }

                    bitList.RemoveAt(i);
                }
            else
                return new List<byte> { };

            return bitList;
        }
    }
}
