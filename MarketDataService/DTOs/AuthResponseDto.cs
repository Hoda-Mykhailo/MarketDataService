using Newtonsoft.Json;

namespace MarketDataService.DTOs
{
    public class AuthResponseDto
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
