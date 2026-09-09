namespace DevCue.Utilities;

public static class ConsoleHelper
{
    private static void PrintTagWithMessage(ConsoleColor color, string tag, string message)
    {
        
        Console.BackgroundColor = color;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write($" [{tag}] ");
        Console.ResetColor();
        Console.WriteLine($" {message}");
    }
    public static void Severe(string message)
    {
        PrintTagWithMessage(ConsoleColor.Red, "SEVERE", message);
    }
    public static void Error(string message)
    {
        PrintTagWithMessage(ConsoleColor.Red, "ERROR", message);
    }
    public static void Warn(string message)
    {
        PrintTagWithMessage(ConsoleColor.DarkYellow, "WARN", message);
    }
    public static void Notice(string message)
    {
        PrintTagWithMessage(ConsoleColor.DarkYellow, "NOTICE", message);
    }
}