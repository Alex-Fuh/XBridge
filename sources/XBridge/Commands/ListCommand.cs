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

    public async Task Execute()
    {
        List<Message> test = await _messageQueryService.GetEntriesForToday();
        foreach (var message in test)
        {
            Console.WriteLine(message.CreatedAt + " " + message.Project.Name + " : " + message.ProjectMessage);
        }
    }
}