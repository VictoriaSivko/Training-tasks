using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(5);
            timer.TimerEvent += MassegeTimer;
            timer.StartCountdown(3);

            try
            {
                timer.StartCountdown(7);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void MassegeTimer(string massege)
        {
            Console.WriteLine(massege);
        }
    }
}
