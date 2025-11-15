using Microsoft.EntityFrameworkCore;

namespace XBridge.Data;

[PrimaryKey(nameof(Id))]
public class Message
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    public string ProjectMessage { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}