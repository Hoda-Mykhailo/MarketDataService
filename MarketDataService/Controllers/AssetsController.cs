using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/assets")]
public class AssetsController : ControllerBase
{
    private readonly AssetService _service;

    public AssetsController(AssetService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await _service.GetAllAsync();
        return Ok(data.Select(a => new { a.Symbol }));
    }
}