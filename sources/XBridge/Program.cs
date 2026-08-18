using Microsoft.EntityFrameworkCore;
using XBridge;
using XBridge.Commands;
using XBridge.Data.Database;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BridgeDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString"))
        );

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