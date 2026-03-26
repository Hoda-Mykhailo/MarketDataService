namespace MarketDataService.DTOs
{
    public class AssetDto
    {
        public Guid Id { get; set; }

        public string Symbol { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
