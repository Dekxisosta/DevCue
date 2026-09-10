using DevCue.Services;
namespace DevCue.Controllers;

public class MainController
{
    public void Run(string[] args)
    {
        new CommandFactory()
            .Build(args.Length<=0? "": args[0])
            .Execute(args.Skip(1).ToArray());
    }
}