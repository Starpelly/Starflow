using System;

namespace Starflow
{
    public class Debug
    {
        public static string LogString = string.Empty;

        public enum LogType
        {
            Normal = 0,
            Warning,
            Error
        }

        public static void Log(object message)
        {
            Console.WriteLine(message);
            AppendString(message, LogType.Normal);
            // System.Diagnostics.Debug.WriteLine(message);
        }

        public static void LogError(object message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            AppendString(message, LogType.Error);
        }

        internal static void AppendString(object str, LogType logType)
        {
            LogString += $"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {str}\n";
        }
    }
}
