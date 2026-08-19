using Microsoft.EntityFrameworkCore;
using XBridge.Data.Database;
using XBridge.Service.Interface;

namespace XBridge.Service;

public class ProjectService : IProjectService
{
    private readonly BridgeDbContext _dbContext;
    
    public ProjectService(BridgeDbContext db)
    {
        _dbContext = db;
    }

    public async Task<Project?> CheckIfProjectExists(String projectName)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Name == projectName);
        if (project == null)
        {
            project = await CreateNewProject(projectName);
        }
        return project;
    }
    
    
    public async Task<Project?> CreateNewProject(String projectName)
    {
        var project = new Project()
        {
            Name = projectName,
            CreatedAt = DateTime.Now
        };
        
        _dbContext.Projects.Add(project);
        await _dbContext.SaveChangesAsync();
        return project;
    }
    
    
    public async Task<Project?> GetLastUsedProject()
    {
        return await _dbContext.Message.OrderByDescending(x => x.CreatedAt).Select(x => x.Project)
            .FirstOrDefaultAsync();
    }
}