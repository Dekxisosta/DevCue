using DevCue.Models;
using System.Reflection;

namespace DevCue.Services;

public class CommandDiscovery
{
    public CommandInfo[] GetCommandsWithDefinitions()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type =>
                type.Namespace == "DevCue.Commands" &&
                typeof(Command).IsAssignableFrom(type) &&
                !type.IsAbstract)
            .OrderBy(type => type.Name)
            .Select(type =>
                type.GetProperty(
                    "Info",
                    BindingFlags.Public | BindingFlags.Static
                )?.GetValue(null) as CommandInfo
            )
            .Where(info => info is not null)
            .ToArray()!;
    }
}