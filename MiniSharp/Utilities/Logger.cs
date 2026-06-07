using System.Runtime.CompilerServices;

namespace MiniSharp.Utilities;

public static class Logger
{
    public static void Info(string msg, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("[INFO]: " + msg + " File path: " + file + " At line: " + line);
        Console.ResetColor();
    }

    public static void Error(string msg, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[ERROR]: " + msg + " File path: " + file + " At line: " + line);
        Console.ResetColor();
    }

    public static void Fatal(string msg, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("[FATAL]: " + msg + " File path: " + file + " At line: " + line);
        Console.ResetColor();
    }

    public static void Warn(string msg, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[WARN]: " + msg + " File path: " + file + " At line: " + line);
        Console.ResetColor();
    }

    public static void Debug(string msg, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[DEBUG]: " + msg + " File path: " + file + " At line: " + line);
        Console.ResetColor();
    }

    public static void Trace(string msg, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("[TRACE]: " + msg + " File path: " + file + " At line: " + line);
        Console.ResetColor();
    }
}