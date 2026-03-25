namespace MarketDataService.Domain.Entities
{
    public class Price
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public decimal Value { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Asset Asset { get; set; } = null!;
    }
}
