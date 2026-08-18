using XBridge.Service;

namespace XBridge;

public class UserInput
{
    private readonly InputParser _dictionary;

    public UserInput(InputParser dictionary)
    {
        _dictionary = dictionary;
    }

    public void ReadLine()
    {
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
                Console.WriteLine(input);
            }
        }
    }
}