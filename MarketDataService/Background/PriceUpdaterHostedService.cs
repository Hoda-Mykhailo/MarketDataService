using MarketDataService.Infrastructure.Fintacharts;
using MarketDataService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MarketDataService.Background
{
    public class PriceUpdaterHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public PriceUpdaterHostedService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();

            var ws = scope.ServiceProvider
                .GetRequiredService<FintachartsWebSocketClient>();

            await ws.StartAsync(async (msg) =>
            {
                using var innerScope = _scopeFactory.CreateScope();
                var db = innerScope.ServiceProvider.GetRequiredService<AppDbContext>();

                dynamic data = JsonConvert.DeserializeObject(msg)!;

                if (data?.price != null)
                {
                    string symbol = data.symbol;
                    decimal priceValue = data.price;

                    var asset = await db.Assets
                        .FirstOrDefaultAsync(a => a.Symbol == symbol, stoppingToken);

                    if (asset == null) return;

                    db.Prices.Add(new Domain.Entities.Price
                    {
                        AssetId = asset.Id,
                        Value = priceValue,
                        UpdatedAt = DateTime.UtcNow
                    });

                    await db.SaveChangesAsync(stoppingToken);
                }

            }, stoppingToken);
        }
    }
}