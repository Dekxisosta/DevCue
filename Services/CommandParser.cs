using DevCue.Types;
namespace DevCue.Services;

public class CommandParser
{
    public CommandType ParseCommand(string input)
    {
        return input.ToLowerInvariant() switch
        {
            _ => CommandType.NotFound
        };
    }
}
