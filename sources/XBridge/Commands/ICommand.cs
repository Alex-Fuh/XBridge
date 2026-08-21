namespace XBridge.Commands;

public interface ICommand
{
    string Name { get; }
    string Description { get; }
    string Syntax { get; }
    Task Execute();
}