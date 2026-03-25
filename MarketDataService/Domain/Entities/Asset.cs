namespace MarketDataService.Domain.Entities
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; } = null!;
        public string Provider { get; set; } = "oanda";
        public string Kind { get; set; } = "forex";
    }
}
