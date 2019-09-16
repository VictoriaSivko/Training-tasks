using NLog;
using System;

namespace FileCabinet
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Trace("Session started.");

            UI uI = new UI();
            uI.WorkWithFileCabinet();

            Console.Write("Please press any key on your keyboard to end the session...");
            Console.ReadKey();

            logger.Trace("Session ended.");
        }
    }
}
