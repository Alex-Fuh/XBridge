using XBridge.Commands;

namespace XBridge;

public class InputParser
{
    private static List<string> commndList = ["help", "sockeye"];
    
    
    private readonly Dictionary<string, ICommand> _commands;

    public InputParser(IEnumerable<ICommand> commands)
    {
        _commands = commands.ToDictionary(c => c.Name); 
    }
    public ICommand? Find(string input) => _commands.GetValueOrDefault(input);
    
}