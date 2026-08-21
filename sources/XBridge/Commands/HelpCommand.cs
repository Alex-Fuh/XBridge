using XBridge.Commands;

namespace XBridge;

public class HelpCommand : ICommand
{
    public string Name => "help";
    public string Description => "Shows this list of available commands.";
    public string Syntax => "";

    private readonly IServiceProvider _services;

    public HelpCommand(IServiceProvider services)
    {
        _services = services;
    }


    public Task Execute()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;

        Console.WriteLine("These are the available commands:\n" +
                          "project:message\n" +
                          "\tWrites an entry to the database; if no project is specified, " +
                          "the recently used project is selected.");

        foreach (var command in _services.GetServices<ICommand>())
        {
            if (command.Name == "help")
            {
                continue;
            }

            Console.WriteLine($"{command.Name} {command.Syntax}\n\t{command.Description}");
        }

        Console.ResetColor();
        return Task.CompletedTask;
    }
}