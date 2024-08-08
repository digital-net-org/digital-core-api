using Safari.Net.Core.Messages;
using SafariDigital.Services.AuthenticationService.Models;

namespace SafariDigital.Services.AuthenticationService;

public interface IAuthenticationService
{
    string GeneratePassword(string password);
    Task<Result<LoginResponse>> Login(string login, string password);
    Task<Result<LoginResponse>> RefreshTokens();
    void Logout();
    void LogoutAll();
}