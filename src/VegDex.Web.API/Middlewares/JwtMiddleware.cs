using VegDex.Application.Interfaces;
using VegDex.Core.Configuration;
using VegDex.Core.Utilities;

namespace VegDex.Web.API.Middlewares;

public class JwtMiddleware
{
    private readonly JwtTokenManager _jwtManager;
    private readonly RequestDelegate _next;
    public JwtMiddleware(RequestDelegate next, IConfigManager configManager)
    {
        _jwtManager = new JwtTokenManager(configManager);
        _next = next;
    }
    async private void AttachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var jwtToken = _jwtManager.Validate(token);
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // attach user to context on successful jwt validation
            context.Items["User"] = await userService.GetById(userId);
        }
        catch
        {
            // NO-OP
            // do nothing if jwt validation fails
        }
    }
    public async Task Invoke(HttpContext context, IUserService userService)
    {
        string? token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token is not null)
            AttachUserToContext(context, userService, token);

        await _next(context);
    }
}
