using DevCue.Services;
using DevCue.Models;
using DevCue.Types;
namespace DevCue.Commands;

public sealed class VersionCommand : Command
{
    private VersionService _versionService;

    public VersionCommand(VersionService versionService)
    {
        _versionService = versionService;
    }
    public static CommandInfo Info => new (
        CommandType.Version,
        ["-v", "--version", "version"],
        "Displays the current version of DevCue"
    );
    public override void Execute(string[] args)
    {
        Console.WriteLine(_versionService.GetVersion());
    }
}