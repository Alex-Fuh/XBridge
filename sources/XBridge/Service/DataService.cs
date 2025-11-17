using XBridge.Data.Database;

namespace XBridge.Service;

public class DataService
{
    private readonly BridgeDbContext db;
    
    public DataService(BridgeDbContext db)
    {
        this.db = db;
    }
    
    public async Task<Project> AddProject(string name)
    {
        var newProject = new Project{ Name = name };
        db.Projects.Add(newProject);
        await db.SaveChangesAsync();
        return newProject;
    }
}