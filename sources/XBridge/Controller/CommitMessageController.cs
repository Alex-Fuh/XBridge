using Microsoft.AspNetCore.Mvc;
using XBridge.Dto;
using XBridge.Service.Interface;

namespace XBridge.Controller;

[ApiController]
[Route("CommitMessageController")]
public class CommitMessageController : ControllerBase
{
    
    public readonly ICommitMessageService _commitMessageService;
    
    public CommitMessageController(ICommitMessageService commitMessageService)
    {
        _commitMessageService = commitMessageService;
    }

    [HttpGet("GetLastUsedProject")]
    [ProducesResponseType<ProjectDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLastUsedProject()
    {
        var project = await _commitMessageService.GetLastUsedProject();

        var dto = new ProjectDto
        {
            ProjectName = project.Name,
        };
        
        return Ok(dto);
    }

    
}