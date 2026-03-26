using System.Net.Http.Headers;

namespace MarketDataService.Infrastructure.Fintacharts
{
    public class FintachartsRestClient
    {
        private readonly HttpClient _http;
        private readonly AuthClient _auth;

        public FintachartsRestClient(HttpClient http, AuthClient auth)
        {
            _http = http;
            _auth = auth;
        }

        public async Task<string> GetInstrumentsAsync()
        {
            var token = await _auth.GetTokenAsync();

            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.GetAsync(
                "https://platform.fintacharts.com/api/instruments/v1/instruments?provider=oanda&kind=forex");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fetch instruments");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
