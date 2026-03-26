using MarketDataService.Infrastructure.Fintacharts;
using MarketDataService.Infrastructure.Persistence;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace MarketDataService.Background
{
    public class PriceUpdaterHostedService : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly FintachartsWebSocketClient _ws;

        public PriceUpdaterHostedService(IServiceProvider provider, FintachartsWebSocketClient ws)
        {
            _provider = provider;
            _ws = ws;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _ws.StartAsync(async (msg) =>
            {
                using var scope = _provider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                dynamic data = JsonConvert.DeserializeObject(msg)!;

                if (data.price != null)
                {
                    var symbol = (string)data.symbol;
                    var priceValue = (decimal)data.price;

                    var asset = db.Assets.FirstOrDefault(a => a.Symbol == symbol);

                    if (asset == null) return;

                    db.Prices.Add(new Domain.Entities.Price
                    {
                        AssetId = asset.Id,
                        Value = priceValue,
                        UpdatedAt = DateTime.UtcNow
                    });

                    await db.SaveChangesAsync();
                }

            }, stoppingToken);
        }
    }
}
