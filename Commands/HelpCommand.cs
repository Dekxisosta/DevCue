using DevCue.Services;
using DevCue.Models;
using DevCue.Types;
namespace DevCue.Commands;

public sealed class HelpCommand : Command
{
    private CommandDiscovery _discoveryService;
    public HelpCommand(CommandDiscovery discoveryService)
    {
        _discoveryService = discoveryService;
    }
    public static CommandInfo Info => new(
        CommandType.Help,
        ["help", "-h", "--help"],
        "List all available commands"
    );
    public override void Execute(string[] args)
    {
        Console.WriteLine("\nAll available commands, type devcue <command alias> <...>");   
        foreach (CommandInfo commandInfo in _discoveryService.GetCommandsWithDefinitions())
        {
            if(commandInfo.Aliases.Length==0) continue;

            Console.WriteLine(
                $"{string.Join(", ", commandInfo.Aliases),-20} | {commandInfo.Description}"
            );
            
        }
        Console.WriteLine();
    }
}