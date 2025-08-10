using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController(IClienteService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        => Ok(await service.GetAllAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ClienteDto>> Get(long id)
    {
        var cliente = await service.GetByIdAsync(id);
        return cliente is null ? NotFound() : Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClienteDto dto)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        var id = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Put(long id, [FromBody] ClienteDto dto)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        var updated = await service.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var removed = await service.DeleteAsync(id);
        return removed ? NoContent() : NotFound();
    }
}
