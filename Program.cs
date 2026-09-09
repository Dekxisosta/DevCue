using DevCue.Utilities;
using DevCue.Controllers;
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            new MainController().Run(args);
        }
        catch(Exception e)
        {
            ConsoleHelper.Error(e.Message);
        }
    }
}