using Microsoft.EntityFrameworkCore;
using XBridge.Data.Database;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BridgeDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString"))
        );
        
        var app = builder.Build();
        app.Run();
    }
}