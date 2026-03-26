using MarketDataService.Domain.Entities;
using MarketDataService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class PriceService
{
    private readonly AppDbContext _db;

    public PriceService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Price>> GetPricesAsync(List<string> symbols)
    {
        return await _db.Prices
            .Include(p => p.Asset)
            .Where(p => symbols.Contains(p.Asset.Symbol))
            .OrderByDescending(p => p.UpdatedAt)
            .ToListAsync();
    }
}