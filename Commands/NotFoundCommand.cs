using DevCue.Utilities;
namespace DevCue.Commands;

public class NotFoundCommand : Command
{
    public override void Execute(string[] args)
    {
        ConsoleHelper.Notice("Command not found. To see available commands, type: devcue --help, -h, or help");
    }
}