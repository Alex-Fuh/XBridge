using XBridge.Data.Database;
using XBridge.Service;
using XBridge.Service.Interface;

namespace XBridge;

public class UserInput
{
    private readonly InputParser _dictionary;
    private readonly ICommitMessageService _commitMessageService;
    

    public UserInput(InputParser dictionary,  ICommitMessageService commitMessageService)
    {
        _dictionary = dictionary;
        _commitMessageService = commitMessageService;
    }

    public async Task ReadLine()
    {
        var currentProject = await _commitMessageService.GetLastUsedProject();
        
        var input = "";
        
        while (true)
        {
            Console.Write("> ");
            input = Console.ReadLine();

            if (input == "")
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
               currentProject = await _commitMessageService.CreateNewMessage(input, currentProject);
            }
        }
    }
}