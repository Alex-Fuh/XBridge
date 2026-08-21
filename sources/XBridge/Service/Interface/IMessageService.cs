using XBridge.Data.Database;

namespace XBridge.Service.Interface;

public interface IMessageService
{
    public Task<Project?> CreateNewMessage(String userInput, Project? project);
}