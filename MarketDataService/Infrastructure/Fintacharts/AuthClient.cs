using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace MarketDataService.Infrastructure.Fintacharts
{
    public class AuthClient
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public AuthClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        public async Task<string> GetTokenAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                "/identity/realms/fintatech/protocol/openid-connect/token");

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "password",
                ["client_id"] = "app-cli",
                ["username"] = _config["Fintacharts:Username"],
                ["password"] = _config["Fintacharts:Password"]
            });

            var response = await _http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Auth failed: {response.StatusCode}");

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(json)!;

            return data.access_token;
        }
    }
}