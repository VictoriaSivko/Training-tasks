using System.Collections.Generic;
using System;

namespace NET.A._2019.Sivko._02
{
    public class Filter
    {
        ///<summary>
        ///The FilterDigit method returns a list of numbers containing a given digit
        ///</summary>
        ///<param name="source">Accepts a list of numbers</param>
        ///<param name="number">Takes the required digit</param>
        ///<returns>Filtered list</returns>
        public static List<int> FilterDigit(List<int> source, int number)
        {
            if (number >= 10 || number < 0)
                throw new Exception("Number must be a digit");

            List<int> result = new List<int>();
            foreach(int i in source)
            {
                int temp = i;
                while (temp > 0)
                {
                    if (temp % 10 == number && !result.Contains(i))
                        result.Add(i);
                    temp /= 10;
                }
            }

            return result;
        }
    }
}
