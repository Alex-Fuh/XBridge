using XBridge.Commands;

namespace XBridge;

public class InputParser
{
    private readonly Dictionary<string, ICommand> _commands;

    public InputParser(IEnumerable<ICommand> commands)
    {
        _commands = commands.ToDictionary(c => c.Name);
    }

    public ICommand? Find(string input)
    {
        return _commands.GetValueOrDefault(input);
    }
}