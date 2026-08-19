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

    public async Task<Project?> CreateNewMessage(String userInput, Project? project)
    {
        var messageString = "";
        Project currentProject = project;
        
        if (userInput.Contains(":"))
        {
            var projectName = userInput.Split(':')[0]; 
            messageString = userInput.Split(':')[1];
            currentProject = await CheckIfProjectExists(projectName);
        }
        else
        {
            messageString = userInput;
        }

        if (currentProject == null)
        {
            throw  new Exception("You must enter a valid project name");
        }
        
        var message = new Message()
        {
            ProjectMessage = messageString,
            CreatedAt = DateTime.Now,
            Project = currentProject 
        };

        _dbContext.Message.Add(message);
        await _dbContext.SaveChangesAsync();
        
        return currentProject;
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