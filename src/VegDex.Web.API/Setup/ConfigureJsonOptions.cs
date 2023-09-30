using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;

namespace VegDex.Web.API.Setup;

public class ConfigureJsonOptions : IConfigureOptions<JsonOptions>
{
    private static readonly ILogger _logger = Log.ForContext<ConfigureJsonOptions>();
    /// <inheritdoc/>
    public void Configure(JsonOptions options)
    {
        _logger.Debug("Configuring JsonOptions...");
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }
}
