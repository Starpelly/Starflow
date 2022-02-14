using System;

namespace Tickflow
{
    public class Debug
    {
        public static void Log(object message)
        {
            Console.WriteLine(message);
        }

        public static void LogError(object message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
