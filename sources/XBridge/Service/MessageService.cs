using Microsoft.EntityFrameworkCore;
using XBridge.Data.Database;
using XBridge.Service.Interface;

namespace XBridge.Service;

public class MessageService : IMessageService
{
    
    private readonly BridgeDbContext _dbContext;
    private readonly IProjectService _projectService;
    
    public MessageService(BridgeDbContext db,  IProjectService projectService)
    {
        _dbContext = db;
        _projectService = projectService;
    }

    public async Task<Project?> CreateNewMessage(String userInput, Project? project)
    {
        var messageString = "";
        Project currentProject = project;
        
        if (userInput.Contains(":"))
        {
            var projectName = userInput.Split(':')[0]; 
            messageString = userInput.Split(':')[1];
            currentProject = await _projectService.CheckIfProjectExists(projectName);
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
    


}