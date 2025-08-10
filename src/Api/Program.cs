using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication("Test")
    .AddScheme<AuthenticationSchemeOptions, Api.TestAuthHandler>("Test", options => { });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Api.AuthConstants.AdminPolicy,
        policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
