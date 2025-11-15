using Microsoft.EntityFrameworkCore;

namespace XBridge.Data;

public class BridgeDbContext : DbContext
{
    public BridgeDbContext(DbContextOptions<BridgeDbContext> options) : base(options) { }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<Message> Message { get; set; }
}

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
[PrimaryKey(nameof(Id))]
public class Message
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    public string ProjectMessage { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
