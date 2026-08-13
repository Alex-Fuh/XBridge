using XBridge.Data.Database;

namespace XBridge.Service;

public class DataService
{
    private readonly BridgeDbContext _dbContext;
    
    public DataService(BridgeDbContext db)
    {
        _dbContext = db;
    }
    
    public async Task<Project> AddProject(string name)
    {
        var newProject = new Project{ Name = name };
        _dbContext.Projects.Add(newProject);
        await _dbContext.SaveChangesAsync();
        return newProject;
    }
}