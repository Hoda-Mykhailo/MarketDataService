using Newtonsoft.Json;

namespace MarketDataService.DTOs
{
    public class PriceUpdateDto
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
