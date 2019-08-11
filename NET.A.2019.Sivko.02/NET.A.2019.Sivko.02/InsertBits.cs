using System;

namespace NET.A._2019.Sivko._02
{
    public class InsertBits
    {
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j || i > 31 || j > 31)
                throw new IndexOutOfRangeException("Wrong indices of the bits to insert (i or(and) j).");

            int[] bitNumberSource = ConvertIntToBitArray(numberSource);
            int[] bitNumberIn = ConvertIntToBitArray(numberIn);

            //Insert the second number into the first
            for (int x = i, y = 0; x<=j ; x++, y++)
                bitNumberSource[x] = bitNumberIn[y];

            return ConvertBitArrayToInt(bitNumberSource);
        }

        private static int ConvertBitArrayToInt(int[] bytes)
        {
            int result = 0;

            for (int i = 0, power = 1; i < 31; i++, power *= 2)
                result += bytes[i] * power;

            if (bytes[31] == 1)
                return -result;
            else
                return result;
        }

        private static int[] ConvertIntToBitArray(int x)
        {
            int[] temp = new int[32];
            if (x < 0)
            {
                temp[31] = 1;
                x = Math.Abs(x);
            }
            for (int i = 0; i < 31; i++)
                temp[i] = (x >> i) & 1;
            return temp;
        }
    }
}
