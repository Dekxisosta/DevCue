using DevCue.Utilities;
using DevCue.Models;
using DevCue.Types;

namespace DevCue.Commands;

public sealed class NotFoundCommand : Command {
    public static CommandInfo Info => new(CommandType.NotFound, [], "");
    public override void Execute(string[] args)
    {
        ConsoleHelper.Notice("Command not found. To see available commands, type: devcue --help, -h, or help");
    }
}