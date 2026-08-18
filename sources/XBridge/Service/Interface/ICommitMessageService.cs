using XBridge.Data.Database;

namespace XBridge.Service.Interface;

public interface ICommitMessageService
{
    public Task CreateNewMessage(String userInput);
    public Task CheckIfProjectExists(String projectName);
    public Task CreateNewProject(String projectName);
    public Task<Project?> GetLastUsedProject();

}