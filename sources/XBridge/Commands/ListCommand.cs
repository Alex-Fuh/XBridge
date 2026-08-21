using XBridge.Data.Database;
using XBridge.Service.Interface;

namespace XBridge.Commands;

public class ListCommand : ICommand
{
    private readonly IMessageQueryService _messageQueryService;

    public ListCommand(IMessageQueryService messageQueryService)
    {
        _messageQueryService = messageQueryService;
    }

    public string Name => "list";
    public string Description => "Lists today's entries, or a week/month if given.";
    public string Syntax => "[week | month]";

    public async Task Execute()
    {
        List<Message> test = await _messageQueryService.GetEntriesForToday();
        foreach (var message in test)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(message.CreatedAt + " " + message.Project.Name + " : " + message.ProjectMessage);
            Console.ResetColor();
        }
    }
}