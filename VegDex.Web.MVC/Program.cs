using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using VegDex.Core.Configuration;
using VegDex.Infrastructure.Context;
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Error)
    .WriteTo.Console(outputTemplate:
        "{Timestamp:yyyy-MM-dd HH:mm:ss.ff zzz} [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}"
    )
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<VegDexSettings>(builder.Configuration);

// Set up database
string connectionString = builder.Configuration.GetConnectionString("Default") ??
                          throw new InvalidOperationException("No default connection string found");
builder.Services.AddDbContext<VegDexContext>(c =>
    c.UseSqlite(connectionString)
);

var app = builder.Build();

try
{
    Log.Information("Attempting to apply migrations");
    using var scope = app.Services.CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<VegDexContext>();
    context.Database.MigrateAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unable to apply migrations");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (builder.Configuration.GetValue<bool>("HttpRedirection"))
{
    app.UseHttpsRedirection();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

try
{
    Log.Information("Starting application");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
