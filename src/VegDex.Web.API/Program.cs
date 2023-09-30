using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using VegDex.Infrastructure.Context;

namespace VegDex.Web.API;

public class Program
{
    private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
            false, true)
        .AddEnvironmentVariables()
        .Build();
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                webBuilder.UseConfiguration(Configuration);
                webBuilder.UseIISIntegration();
                webBuilder.UseStartup<Startup>();
            })
            .UseSerilog();
    }
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Error)
            .WriteTo.Console(outputTemplate:
                "{Timestamp:yyyy-MM-dd HH:mm:ss.ff zzz} [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}"
            )
            .CreateLogger();

        var host = CreateHostBuilder(args)
            .Build();

        try
        {
            Log.Information("Attempting to apply app db migrations");
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<VegDexContext>();
            context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Unable to apply migrations");
        }
        try
        {
            Log.Information("Starting application");
            host.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
