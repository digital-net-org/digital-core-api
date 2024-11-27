using Digital.Net.Core.Messages;
using Microsoft.AspNetCore.Http;
using SafariDigital.Data.Models.Database.Documents;
using SafariDigital.Data.Models.Database.Users;

namespace SafariDigital.Services.Users;

public interface IUserService
{
    Task<Result> UpdatePassword(User user, string currentPassword, string newPassword);
    Task<Result<Document>> UpdateAvatar(User user, IFormFile form);
    Task<Result> RemoveUserAvatar(User user);
}