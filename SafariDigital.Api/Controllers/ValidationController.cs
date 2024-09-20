using Microsoft.AspNetCore.Mvc;
using SafariDigital.Api.Attributes;
using SafariDigital.Core;
using SafariDigital.Core.Application;
using SafariDigital.Data.Models.Database;
using SafariDigital.Services.Authentication;

namespace SafariDigital.Api.Controllers;

[ApiController, Route("[controller]")]
public class ValidationController(IConfiguration configuration) : ControllerBase
{
    [HttpGet("username/pattern")]
    public ActionResult<string> GetUsernamePattern() => Ok(RegularExpressions.GetUsernameRegex().ToString());

    [HttpGet("email/pattern")]
    public ActionResult<string> GetEmailPattern() => Ok(RegularExpressions.GetEmailRegex().ToString());

    [HttpGet("password/pattern"), Authorize(Role = EUserRole.User)]
    public ActionResult<string> GetPasswordPattern() => Ok(configuration.GetPasswordRegex().ToString());

    [HttpGet("avatar/size")]
    public ActionResult<long> GetAvatarMaxSize() =>
        Ok(configuration.GetSection<long>(EApplicationSetting.FileSystemMaxAvatarSize));
}