using System.Text.Json;
using DevCue.Types;
namespace DevCue.Services;
public class ConfigService
{
    private bool IsSupported()
    {
        return OperatingSystem.IsWindows() || OperatingSystem.IsLinux() || OperatingSystem.IsMacOS();
    }
    private string GetOSAppDataPath()
    {
        if (!IsSupported())
        {
            throw new PlatformNotSupportedException(
                "DevCue does not support this operating system."
            );
        }
        string configDir = "";
        if (OperatingSystem.IsWindows())
        {
            configDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        if (OperatingSystem.IsLinux())
        {
            configDir = Environment.GetEnvironmentVariable("XDG_CONFIG_HOME")
                        ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config");
        }
        if (OperatingSystem.IsMacOS())
        {
            configDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Library",
                "Application Support"
            );
        }
        return configDir;
    }
    private string GetOrCreateDevCuePath()
    {
        string devCueDir = Path.Combine(GetOSAppDataPath(), "devcue");
        Directory.CreateDirectory(devCueDir);
        return Path.Combine();
    }
    private string GetOrCreateConfigPath()
    {
        string configPath = Path.Combine(GetOrCreateDevCuePath(), "config.json");
        string content = File.Exists(configPath)
            ? File.ReadAllText(configPath)
            : "";

        if (string.IsNullOrWhiteSpace(content))
        {
            File.WriteAllText(configPath, "{}");
        }
        return configPath;
    }
    public DevCueConfig Load()
    {
        DevCueConfig? config = JsonSerializer.Deserialize<DevCueConfig>(GetOrCreateConfigPath());
        if (config is null)
        {
            throw new InvalidOperationException(
                "Failed to load DevCue configuration."
            );
        }
        return config;
    }
    public void Save(DevCueConfig newConfig)
    {
        string configPath = GetOrCreateConfigPath();
        if (configPath is null)
        {
            throw new InvalidOperationException(
                "Failed to perform write in DevCue configuration. Impossible state reached"
            );
        }
        string json = JsonSerializer.Serialize(newConfig, new JsonSerializerOptions{WriteIndented = true});
        File.WriteAllText(configPath, json);
    }
}