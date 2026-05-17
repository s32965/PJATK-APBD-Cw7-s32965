using Cw7.Services;
using Cw7.Excepetions;
using Microsoft.AspNetCore.Mvc;

namespace Cw7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController(IPCService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllAsync(cancellationToken));
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetComponentsById([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.GetComponentsById(id, cancellationToken));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}