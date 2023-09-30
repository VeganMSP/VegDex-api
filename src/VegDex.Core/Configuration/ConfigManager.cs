using Microsoft.Extensions.Configuration;
using VegDex.Core.Entities.Config;

namespace VegDex.Core.Configuration;

public interface IConfigManager
{
    App App { get; set; }
    string GetConfigValue(string key);
}
public class ConfigManager : IConfigManager
{
    public ConfigManager() { }
    public ConfigManager(IConfiguration configuration)
    {
        App = configuration.GetSection("App").Get<App>() ?? throw new InvalidOperationException();
    }
    /// <inheritdoc/>
    public App App { get; set; }
    /// <inheritdoc/>
    public string GetConfigValue(string key) => throw new NotImplementedException();
}
