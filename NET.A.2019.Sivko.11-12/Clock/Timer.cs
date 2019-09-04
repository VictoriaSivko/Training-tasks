using System;
using System.Threading;

namespace Clock
{
    /// <summary>
    /// The Clock class implements timer functions
    /// </summary>
    public class Timer
    {
        private long seconds;

        public delegate void Time(string message);

        public event Time TimerEvent;

        public long Seconds
        {
            get { return seconds; }
            set
            {
                if (seconds < 0)
                {
                    throw new ArgumentException("Attempt to use negative seconds");
                }
                else
                {
                    seconds = value;
                }
            }
        }

        public Timer(long seconds)
        {
            Seconds = seconds;
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        /// <param name="stopSecond">Seconds after which the timer should stop.</param>
        public void StartCountdown(long stopSecond)
        {
            if (stopSecond < 0)
            {
                throw new ArgumentException("Attempt to use negative seconds.");
            }

            if(stopSecond > seconds)
            {
                throw new ArgumentException("The seconds after which the timer must be stopped exceed the number of seconds the timer is running.");
            }

            if (TimerEvent != null)
            {
                TimerEvent("Started the countdown.");
            }

            long temp = seconds;
            while (temp != seconds - stopSecond)
            {
                Thread.Sleep(1000);
                temp--;
            }

            if (TimerEvent != null)
            {
                TimerEvent($"Time was stopped after {stopSecond} seconds. Left {seconds - stopSecond} seconds.");
            }           
        }
    }
}
