using Microsoft.EntityFrameworkCore;

namespace XBridge.Data;

[PrimaryKey(nameof(Id))]
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? SAPtaskID1  { get; set; }
    public string? SAPtaskID2 { get; set; }

    public List<Message> Message { get; set; } = new();
}