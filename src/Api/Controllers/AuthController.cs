using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("token")]
    public IActionResult GenerateToken([FromBody] string username)
    {
        // Simplified token generation placeholder
        return Ok(new { token = $"dummy-token-for-{username}" });
    }
}
