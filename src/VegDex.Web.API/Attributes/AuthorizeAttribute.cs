using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VegDex.Core.Entities;

namespace VegDex.Web.API.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    /// <inheritdoc />
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (User?)context.HttpContext.Items["User"];
        if (user is null)
        {
            // not logged in
            context.Result = new JsonResult(new
            {
                message = "Unauthorized"
            })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
    }
}
