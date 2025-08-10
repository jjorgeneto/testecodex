using System.Security.Claims;
using System.Reflection;
using Api;
using Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Tests;

public class ClientesAuthorizationTests
{
    [Fact]
    public void Controller_Has_AuthorizeAttribute_With_AdminPolicy()
    {
        var attr = typeof(ClientesController).GetCustomAttribute<AuthorizeAttribute>();
        Assert.NotNull(attr);
        Assert.Equal(AuthConstants.AdminPolicy, attr!.Policy);
    }

    [Fact]
    public async Task Policy_Allows_Admin_User()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddAuthorization(o => o.AddPolicy(AuthConstants.AdminPolicy, p => p.RequireRole("Admin")));
        var provider = services.BuildServiceProvider();
        var auth = provider.GetRequiredService<IAuthorizationService>();
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, "Admin") }, "Test"));
        var result = await auth.AuthorizeAsync(user, null, AuthConstants.AdminPolicy);
        Assert.True(result.Succeeded);
    }

    [Fact]
    public async Task Policy_Denies_Non_Admin_User()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddAuthorization(o => o.AddPolicy(AuthConstants.AdminPolicy, p => p.RequireRole("Admin")));
        var provider = services.BuildServiceProvider();
        var auth = provider.GetRequiredService<IAuthorizationService>();
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, "User") }, "Test"));
        var result = await auth.AuthorizeAsync(user, null, AuthConstants.AdminPolicy);
        Assert.False(result.Succeeded);
    }
}
