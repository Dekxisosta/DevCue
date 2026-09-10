using DevCue.Models;
using System.Reflection;
using DevCue.Commands;
using DevCue.Types;
namespace DevCue.Services;

public class CommandFactory
{
    private CommandType ParseType(string input)
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type =>
                type.Namespace == "DevCue.Commands" &&
                typeof(Command).IsAssignableFrom(type) &&
                !type.IsAbstract)
            .Select(type => type.GetProperty(
                "Info",
                BindingFlags.Public | BindingFlags.Static
            ))
            .Where(property => property is not null)
            .Select(property => (CommandInfo)property!.GetValue(null)!)
            .FirstOrDefault(
                
                info => info.Aliases.Contains(
                    input, 
                    StringComparer.OrdinalIgnoreCase
                ),
                new CommandInfo(CommandType.NotFound,[],"") // default value
            )
            .Type;
    }
    public Command Build(string commandName)
    {
        return ParseType(commandName) switch
        {
            CommandType.Help => new HelpCommand(new CommandDiscovery()),
            CommandType.NotFound => new NotFoundCommand(),
            _ => new NotFoundCommand()
        };
    }
}