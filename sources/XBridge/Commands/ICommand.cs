namespace XBridge.Commands;

public interface ICommand
{
    string Name { get; }
    Task Execute();
}