using Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = AuthConstants.AdminPolicy)]
public class ClientesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new[] { "cliente1", "cliente2" });
}
