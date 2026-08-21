using XBridge.Data.Database;
using XBridge.Service;
using XBridge.Service.Interface;

namespace XBridge;

public class UserInput
{
    private readonly InputParser _dictionary;
    private readonly IProjectService _projectService;
    private readonly IMessageService _messageService;
    

    public UserInput(InputParser dictionary,  IProjectService projectService,  IMessageService messageService)
    {
        _dictionary = dictionary;
        _projectService = projectService;
        _messageService = messageService;
    }

    public async Task ReadLine()
    {
        var currentProject = await _projectService.GetLastUsedProject();
        
        var input = "";
        
        while (true)
        {
            Console.Write("> ");
            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                break;
            }

            var compareInputWithCommands = _dictionary.Find(input);
            if (compareInputWithCommands != null)
            {
                compareInputWithCommands.Execute();
            }
            else
            {
               currentProject = await _messageService.CreateNewMessage(input, currentProject);
            }
        }
    }
}