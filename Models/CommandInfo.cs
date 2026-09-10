using DevCue.Types;
namespace DevCue.Models;

public sealed record CommandInfo(
    CommandType Type,
    string[] Aliases,
    string Description
);