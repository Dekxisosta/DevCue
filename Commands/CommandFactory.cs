using DevCue.Types;
using DevCue.Services;

namespace DevCue.Commands;

public class CommandFactory
{
    public Command Build(CommandType type)
    {
        return type switch
        {
            _ => new NotFoundCommand()
        };
    }
}