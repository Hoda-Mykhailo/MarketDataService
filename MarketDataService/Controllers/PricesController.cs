using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/prices")]
public class PricesController : ControllerBase
{
    private readonly PriceService _service;

    public PricesController(PriceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] List<string> symbols)
    {
        var prices = await _service.GetPricesAsync(symbols);

        return Ok(prices.Select(p => new
        {
            symbol = p.Asset.Symbol,
            price = p.Value,
            updatedAt = p.UpdatedAt
        }));
    }
}