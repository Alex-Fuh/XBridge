using Microsoft.EntityFrameworkCore;
using XBridge;
using XBridge.Commands;
using XBridge.Data.Database;
using XBridge.Service;
using XBridge.Service.Interface;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BridgeDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DbConnectionString"))
        );

        builder.Services.AddScoped<ICommitMessageService, CommitMessageService>();
        builder.Services.AddScoped<IGetEntriesForTodayService, GetEntriesForTodayService>();
        builder.Services.AddHostedService<MyService>();
        builder.Services.AddScoped<ICommand, HelpCommand>();
        builder.Services.AddScoped<ICommand, ListCommand>();
        
        var app = builder.Build();

         await MigrateAsync(app);
        
         await app.RunAsync();
       
    }
    
    public static async Task MigrateAsync(IHost host)
    {
        var scopeFactory = host.Services.GetService<IServiceScopeFactory>()
                           ?? throw new NullReferenceException("Failed to receive IServiceScopeFactory.");
        using var scope = scopeFactory.CreateScope();
        var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger(typeof(Program));
        
        if (scope.ServiceProvider.GetService<BridgeDbContext>() is not { } dbContext)
        {
            logger.LogError(
                "Failed to apply migration of {DbContextType} as the service could not be found",
                typeof(BridgeDbContext).FullName
            );
            return;
        }

        await using (dbContext)
        {
            logger.LogInformation(
                "Attempting to migrate against {ConnectionString}",
                dbContext.Database.GetConnectionString()
            );
            await dbContext.Database.MigrateAsync();
        }
    }
    
    
    
}

public class MyService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public MyService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        using var scope = _serviceProvider.CreateScope();
        
        var commands = scope.ServiceProvider.GetRequiredService<IEnumerable<ICommand>>();
        var service  = scope.ServiceProvider.GetRequiredService<ICommitMessageService>();
        
        var parser = new InputParser(commands);
         await new UserInput(parser, service).ReadLine();
        
    }
}

