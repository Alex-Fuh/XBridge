using XBridge.Commands;

namespace XBridge;

public class HelpCommand : ICommand
{
    public string Name => "help";

    public Task Execute()
    {
        Console.WriteLine("Commands: help, list");
        return Task.CompletedTask;
    }
}