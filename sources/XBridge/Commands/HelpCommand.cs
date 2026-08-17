using XBridge.Commands;

namespace XBridge;

public class HelpCommand : ICommand
{

    public string Name => "help";
    public void Execute() => Console.WriteLine("Commands: help");
    
}