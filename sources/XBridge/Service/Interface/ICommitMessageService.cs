using XBridge.Data.Database;

namespace XBridge.Service.Interface;

public interface ICommitMessageService
{
    public Task<Project?> CreateNewMessage(String userInput, Project? project);
    public Task<Project?> CheckIfProjectExists(String projectName);
    public Task<Project?> CreateNewProject(String projectName);
    public Task<Project?> GetLastUsedProject();

}