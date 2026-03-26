using MarketDataService.Domain.Entities;
using MarketDataService.Infrastructure.Fintacharts;
using MarketDataService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class AssetService
{
    private readonly AppDbContext _db;
    private readonly FintachartsRestClient _client;

    public AssetService(AppDbContext db, FintachartsRestClient client)
    {
        _db = db;
        _client = client;
    }

    public async Task SyncAssetsAsync()
    {
        var json = await _client.GetInstrumentsAsync();

        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json)!;

        foreach (var item in data.data)
        {
            string symbol = item.symbol;

            if (!_db.Assets.Any(a => a.Symbol == symbol))
            {
                _db.Assets.Add(new MarketDataService.Domain.Entities.Asset
                {
                    Symbol = symbol
                });
            }
        }

        await _db.SaveChangesAsync();
    }

    public async Task<List<Asset>> GetAllAsync()
    {
        return await _db.Assets.ToListAsync();
    }
}