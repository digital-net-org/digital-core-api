using SafariDigital.Data.Models.Database;

namespace SafariDigital.Services.JwtService.Models;

public class AuthenticatedUser
{
    public Guid? Id { get; init; }
    public EUserRole? Role { get; init; }

    public string? Token { get; set; } = null;
}