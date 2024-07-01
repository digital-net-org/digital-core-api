using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SafariDigital.Database.Models.User;
using SafariDigital.Services.Authentication.Models;
using SafariLib.Jwt.HttpContext;
using SafariLib.Jwt.Models;
using SafariLib.Jwt.Services;

namespace SafariDigital.Api.Attributes;

[ExcludeFromCodeCoverage] // Tested in Integration tests
[AttributeUsage(AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public EUserRole Role { get; set; }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var jwtService = context.HttpContext.RequestServices.GetRequiredService<IJwtService>();
        var token = context.HttpContext.GetBearerToken();
        var result = jwtService.ValidateToken<AuthenticatedUser>(token);
        var isUserAuthorized = result.Content?.Role >= Role;

        if (isUserAuthorized)
        {
            context.HttpContext.Items["Token"] = JsonSerializer.Serialize(
                new JwtToken<AuthenticatedUser>
                {
                    Content = result.Content,
                    Token = result.Token,
                    SecurityToken = result.SecurityToken
                }
            );
            return;
        }

        context.Result = new JsonResult(result) { StatusCode = 401 };
    }
}