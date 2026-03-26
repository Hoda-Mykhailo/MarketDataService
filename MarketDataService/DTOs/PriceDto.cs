namespace MarketDataService.DTOs
{
    public class PriceDto
    {
        public Guid Id { get; set; }

        public Guid AssetId { get; set; }

        public decimal Value { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
