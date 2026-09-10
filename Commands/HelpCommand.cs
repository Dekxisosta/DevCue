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
        ["help", "-h"],
        "List all available commands"
    );
    public override void Execute(string[] args)
    {
        Console.WriteLine("All available commands, type devcue <command alias> <...>");   
        foreach (CommandInfo commandInfo in _discoveryService.GetCommandsWithDefinitions())
        {
            
            Console.WriteLine(
                $"{string.Join(", ", commandInfo.Aliases):%.15}" 
                + " "
                + $"{commandInfo.Description}"
            );
        }
    }
}