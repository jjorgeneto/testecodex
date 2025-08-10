using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = Api.AuthConstants.AdminPolicy)]
public class ClientesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new[] { "cliente1", "cliente2" });
}
