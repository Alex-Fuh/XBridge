using Microsoft.EntityFrameworkCore;
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
        var messageString = "";
        
        if (userInput.Contains(":"))
        {
            var projectName = userInput.Split(':')[0]; 
            CheckIfProjectExists(projectName);
            
        }

        messageString = userInput.Split(':')[1];
        var message = new Message()
        {
            ProjectMessage = messageString,
            CreatedAt = DateTime.Now
        };
        
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
    
    public async Task<Project?> GetLastUsedProject()
    {
        return await _dbContext.Message.OrderByDescending(x => x.CreatedAt).Select(x => x.Project)
            .FirstOrDefaultAsync();
    }

}