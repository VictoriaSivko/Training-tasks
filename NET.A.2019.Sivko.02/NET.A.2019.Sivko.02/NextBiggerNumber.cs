using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NET.A._2019.Sivko._02
{
    public class NextBiggerNumber
    {
        /// <summary>
        /// The FindNextBiggerNumber method looks for the nearest largest number to the initial one
        /// </summary>
        /// <param name="source">Original number</param>
        /// <returns>The nearest largest number to the initial one</returns>
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

        /// <summary>
        /// The FindNextBiggerNumber method looks for the nearest largest number to the initial one
        /// and returns the elapsed time using the StopWatch class
        /// </summary>
        /// <param name="source">Original number</param>
        /// <returns>The nearest largest number to the initial one</returns>
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

        /// <summary>
        /// The FindNextBiggerNumber method looks for the nearest largest number to the initial one
        /// and returns the elapsed time using DiteTime class to determine time
        /// </summary>
        /// <param name="source">Original number</param>
        /// <returns>The nearest largest number to the initial one</returns>
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

        /// <summary>
        /// The СreateList method creates a list of numbers
        /// </summary>
        /// <param name="source">Original number</param>
        /// <returns>List of digits of original number</returns>
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

        /// <summary>
        /// The FindMaxNumber method finds the largest number
        /// </summary>
        /// <param name="temp">A list containing the digits of the original number</param>
        /// <param name="index">Index of the swaped item</param>
        /// <returns>The largest number</returns>
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

        /// <summary>
        /// The Minimize method approximates the previously found large number
        /// to the original number using selection sorting 
        /// </summary>
        /// <param name="temp">List of digits of original number</param>
        /// <param name="currentIndex">Separates the sorted part of the list from the part to be sorted</param>
        /// <returns>Sorted list containing the desired number</returns>
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

        /// <summary>
        /// The auxiliary method for finding the min digit
        /// </summary>
        /// <param name="temp">List of digits</param>
        /// <param name="n">The index of the extreme element</param>
        /// <returns>The index of the minimum element</returns>
        private static int MinIndex(List<int> temp, int n)
        {
            int result = n - 1;
            for (int i = result; i >= 0; i--)
                if (temp[i] < temp[result])
                    result = i;
            return result;
        }      
    }
}
