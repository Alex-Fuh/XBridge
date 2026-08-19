using XBridge.Data.Database;
using XBridge.Service.Interface;

namespace XBridge.Commands;

public class ListCommand : ICommand
{
    private readonly IGetEntriesForTodayService _getEntriesForTodayService;

    public ListCommand(IGetEntriesForTodayService getEntriesForTodayService)
    {
        _getEntriesForTodayService = getEntriesForTodayService;
    }

    public string Name => "list";

    public async Task Execute()
    {
        List<Message> test = await _getEntriesForTodayService.GetEntriesForToday();
        foreach (var message in test)
        {
            Console.WriteLine(message.Project.Name + " : " + message.ProjectMessage);
        }
    }
}