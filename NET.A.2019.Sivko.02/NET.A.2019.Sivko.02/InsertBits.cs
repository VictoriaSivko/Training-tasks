using System;

namespace NET.A._2019.Sivko._02
{
    public class InsertBits
    {
        ///<summary>
        ///The InsertNumber method inserts the second number into the first at certain bit positions
        ///</summary>
        ///<param name="numberSource">First number</param>
        ///<param name="numberIn">Second number</param>
        ///<param name="i">First bit index</param>
        ///<param name="j">Second bit index</param>
        ///<returns>The first number with bits of the second number at the i-j bit position</returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j || i > 31 || j > 31 || i<0 || j<0)
                throw new IndexOutOfRangeException("Wrong indices of the bits to insert (i or(and) j).");

            int[] bitNumberSource = ConvertIntToBitArray(numberSource);
            int[] bitNumberIn = ConvertIntToBitArray(numberIn);

            //Insert the second number into the first
            for (int x = i, y = 0; x<=j ; x++, y++)
                bitNumberSource[x] = bitNumberIn[y];

            return ConvertBitArrayToInt(bitNumberSource);
        }

        ///<summary>
        ///The ConvertBitArrayToInt method  converts an array of bits to a number
        ///</summary>
        ///<param name="bytes">The array of bits</param>
        ///<returns>The number composed of the bits</returns>
        private static int ConvertBitArrayToInt(int[] bytes)
        {
            int result = 0;

            for (int i = 0, power = 1; i < 31; i++, power *= 2)
                result += bytes[i] * power;

            //If the number is negative
            if (bytes[31] == 1)
                return -result;
            else
                return result;
        }

        ///<summary>
        ///The ConvertIntToBitArray method  converts a number to an array of bits
        ///</summary>
        ///<param name="x">Original number</param>
        ///<returns>The array of the bits</returns>
        private static int[] ConvertIntToBitArray(int x)
        {
            int[] temp = new int[32];

            //If the number is negative
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
