using XBridge.Data.Database;

namespace XBridge.Service.Interface;

public interface IProjectService
{
    public Task<Project?> CheckIfProjectExists(String projectName);
    public Task<Project?> CreateNewProject(String projectName);
    public Task<Project?> GetLastUsedProject();
}