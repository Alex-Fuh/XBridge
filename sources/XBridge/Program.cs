using Microsoft.EntityFrameworkCore;
using XBridge.Data.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BridgeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString"))
);

Console.WriteLine("Press any key to exit...");

var app = builder.Build();
app.Run();

