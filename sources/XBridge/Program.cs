using Microsoft.EntityFrameworkCore;
using XBridge;
using XBridge.Commands;
using XBridge.Controller;
using XBridge.Data.Database;
using XBridge.Service;
using XBridge.Service.Interface;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BridgeDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString"))
        );

        builder.Services.AddScoped<ICommitMessageService, CommitMessageService>();
        
        
        
        var commands = new List<ICommand>
        {
            new HelpCommand(),
        };
        
        var parser = new InputParser(commands);
        new UserInput(parser).ReadLine();
        
        var app = builder.Build();
        app.Run();
    }
}