using System.Collections.Generic;

namespace NET.A._2019.Sivko._02
{
    public class Filter
    {
        //The method returns a list of numbers containing a given digit
        public static List<int> FilterDigit(List<int> source, int number)
        {
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
