using DevCue.Services;
using DevCue.Commands;
using DevCue.Types;

namespace DevCue.Controllers;

public class MainController
{
    public void Run(string[] args)
    {
        CommandType type = args.Length==0? CommandType.NotFound: new CommandParser().ParseCommand(args[0]);
        new CommandFactory().Build(type).Execute(args.Skip(1).ToArray());
    }
}