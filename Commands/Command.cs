namespace DevCue.Commands;

public abstract class Command
{
    public abstract void Execute(string[] args);
}