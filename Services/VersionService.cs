using System.Reflection;
namespace DevCue.Services;

public class VersionService{
    public string GetVersion()
    {
        Version? version = Assembly.GetExecutingAssembly()
            .GetName().Version;

        return version == null? "0.10": version.ToString();
    }
}