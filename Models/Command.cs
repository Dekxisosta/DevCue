namespace DevCue.Models;

public abstract class Command
{
    /*
    For discoverability of the command via help, it must have static metadata
    using the following implementation:

    public static CommandInfo Info => new(...);

    See command info for actual data model
    */
    public abstract void Execute(string[] args);
}