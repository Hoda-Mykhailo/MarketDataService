using Newtonsoft.Json;

namespace MarketDataService.DTOs
{
    public class SubscribeDto
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "subscribe";

        [JsonProperty("symbols")]
        public string[] Symbols { get; set; } = Array.Empty<string>();
    }
}
