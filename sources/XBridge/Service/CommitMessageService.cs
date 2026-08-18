using XBridge.Data.Database;
using XBridge.Service.Interface;

namespace XBridge.Service;

public class CommitMessageService : ICommitMessageService
{
    
    private readonly BridgeDbContext _dbContext;
    
    public CommitMessageService(BridgeDbContext db)
    {
        _dbContext = db;
    }

    public async Task CreateNewMessage(String userInput)
    {
        if (userInput.Contains(":"))
        {
            var projectName = userInput.Split(':')[0]; 
            CheckIfProjectExists(projectName);
        }
        
        // message commit
    }
    
    public async Task CheckIfProjectExists(String projectName)
    {
        var project =  await _dbContext.Projects.FindAsync(projectName);
        if (project == null)
        {
            CreateNewProject(projectName);
        }
    }
    
    public async Task CreateNewProject(String projectName)
    {
        var project = new Project()
        {
            Name = projectName,
            CreatedAt = DateTime.Now
        };
        
        _dbContext.Projects.Add(project);
        await _dbContext.SaveChangesAsync();
    }
    
}