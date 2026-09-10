# DevCue

[.NET](https://dotnet.microsoft.com/)
[C#](https://dotnet.microsoft.com/en-us/languages/csharp)
[NAudio](https://github.com/naudio/NAudio)

A small command-line utility for playing audio cues from the terminal.

Built as a personal C# project to experiment with CLI application architecture, command parsing, configuration management, and audio playback.

**DevCue was written by me and was not written by AI.**

## What's included

* **Command System** — command parsing, command types, factories, and individual command implementations
* **Audio Service** — audio playback functionality
* **Config Service** — persistent configuration and user settings
* **Console Helper** — formatted terminal messages and status tags
* **Cross-platform configuration** — platform-aware configuration paths for Windows, Linux, and macOS
* **CLI Interface** — simple command-based interaction through the terminal

## Commands

```text
devcue <command> [arguments]
```

Available commands:

```text
devcue help
devcue --help
devcue -h

devcue play <cue>

devcue list

devcue config ...
```

Unknown commands display a notice and point the user toward the help command.

## Structure

```text
DevCue/
├── Commands/
│   ├── Command.cs
│   ├── CommandFactory.cs
│   ├── CommandParser.cs
│   ├── PlayCommand.cs
│   ├── HelpCommand.cs
│   └── NotFoundCommand.cs
├── Controllers/
│   └── MainController.cs
├── Services/
│   ├── AudioService.cs
│   └── ConfigService.cs
├── Types/
│   └── CommandType.cs
├── Utilities/
│   └── ConsoleHelper.cs
└── Program.cs
```

## Architecture

DevCue follows a small command-driven architecture:

```text
Terminal
    ↓
Program
    ↓
MainController
    ↓
CommandParser
    ↓
CommandType
    ↓
CommandFactory
    ↓
Command
    ↓
Service
```

Commands only receive the services they actually need. This keeps commands such as `HelpCommand` from initializing unrelated application services.

## Configuration

DevCue stores persistent configuration in a platform-specific user configuration directory.

```text
Windows
%APPDATA%/devcue/

Linux
~/.config/devcue/

macOS
~/Library/Application Support/devcue/
```

Configuration is stored as JSON and can include settings such as audio cues and playback preferences.

## Development

Clone the repository:

```bash
git clone <repository-url>
cd DevCue
```

Build the project:

```bash
dotnet build
```

Run DevCue:

```bash
dotnet run -- help
```

Run a command with arguments:

```bash
dotnet run -- play success
```

## Status

DevCue is currently under development.

The project is primarily being used to learn and experiment with C#, .NET, CLI application design, service boundaries, configuration handling, and clean project architecture.
