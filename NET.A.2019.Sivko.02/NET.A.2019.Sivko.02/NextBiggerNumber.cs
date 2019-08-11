using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NET.A._2019.Sivko._02
{
    public class NextBiggerNumber
    {
        public static int FindNextBiggerNumber(int source)
        {
            //create new List with numbers
            List<int> intList = СreateList(source);

            //Increase the number 
            int index;
            intList = FindMaxNumber(intList, out index);
            if (index == -1)
                return -1;

            //Minimize
            intList = Minimize(intList, index);

            //Make a number
            int answer = 0, temp = 1;
            for (int i = 0; i < intList.Count; i++)
            {
                answer += intList[i] * temp;
                temp *= 10;
            }

            return answer;
        }

        //This method uses the StopWatch class to determine time
        public static int FindNextBiggerNumber(int source, out Stopwatch time)
        {
            time = Stopwatch.StartNew();
            //create new List with numbers
            List<int> intList = СreateList(source);

            //Increase the number 
            int index;
            intList = FindMaxNumber(intList, out index);
            if (index == -1)
            {
                time.Stop();
                return -1;
            }
                

            //Minimize
            intList = Minimize(intList, index);

            //Make a number
            int answer = 0, temp = 1;
            for (int i = 0; i < intList.Count; i++)
            {
                answer += intList[i] * temp;
                temp *= 10;
            }

            time.Stop();

            return answer;
        }

        //This method uses DiteTime class to determine time
        public static int FindNextBiggerNumber(int source, out int time)
        {
            DateTime Start, Stoped;
            TimeSpan Elapsed = new TimeSpan();

            Start = DateTime.Now;

            //create new List with numbers
            List<int> intList = СreateList(source);

            //Increase the number 
            int index;
            intList = FindMaxNumber(intList, out index);
            if (index == -1)
            {
                Stoped = DateTime.Now;
                Elapsed = Stoped.Subtract(Start); //Subtract from Stopped the start time
                time = Elapsed.Milliseconds;
                return -1;
            }

            //Minimize
            intList = Minimize(intList, index);

            //Make a number
            int answer = 0, temp = 1;
            for (int i = 0; i < intList.Count; i++)
            {
                answer += intList[i] * temp;
                temp *= 10;
            }

            Stoped = DateTime.Now;
            Elapsed = Stoped.Subtract(Start);
            time = Elapsed.Milliseconds;
            return answer;
        }

        //The method creates a list of numbers
        private static List<int> СreateList(int source)
        {
            List<int> intList = new List<int>();

            while (source > 0)
            {
                intList.Add(source % 10);
                source /= 10;
            }

            return intList;
        }

        //Sort by selection
        private static List<int> Minimize(List<int> temp, int currentIndex)
        {
            //looking for the index of the minimum element
            while (currentIndex > 1)
            {
                int index = MinIndex(temp, currentIndex);

                int t = temp[currentIndex - 1];
                temp[currentIndex - 1] = temp[index];
                temp[index] = t;

                currentIndex--;
            }
    
            return temp;
        }

        //Method of finding the position of the min element
        private static int MinIndex(List<int> temp, int n)
        {
            int result = n - 1;
            for (int i = result; i >= 0; i--)
                if (temp[i] < temp[result])
                    result = i;
            return result;
        }

        //The method of finding the largest number
        private static List<int> FindMaxNumber(List<int> temp, out int index)
        {
            for (int i = 0; i < temp.Count; i++)
                for (int j = i + 1; j < temp.Count; j++)
                    if (temp[i] > temp[j])
                    {
                        int t = temp[i];
                        temp[i] = temp[j];
                        temp[j] = t;
                        index = j;
                        return temp;
                    }
                    else if (temp[i] < temp[j])
                        break;
            index = -1;
            return temp;
        }
    }
}
