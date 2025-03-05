using System.Net;
using Digital.Core.Api.Test.Collections;
using Digital.Lib.Net.TestTools.Integration;

namespace Digital.Core.Api.Test.Integration.Authentication.JwtTests;

public class JwtAuthorizationTest(AppFactory<Program> fixture) : AuthenticationTest(fixture)
{
    [Fact]
    public async Task LoggedUser_OnProtectedRoute_ShouldBeAuthorized()
    {
        await BaseClient.Login(UserRepository.BuildTestUser());
        var response = await BaseClient.GetAppVersion();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
