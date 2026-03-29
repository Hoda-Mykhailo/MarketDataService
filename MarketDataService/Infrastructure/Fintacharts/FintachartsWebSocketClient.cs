using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace MarketDataService.Infrastructure.Fintacharts
{
    public class FintachartsWebSocketClient
    {
        private readonly IConfiguration _config;
        private readonly AuthClient _auth;

        public FintachartsWebSocketClient(IConfiguration config, AuthClient auth)
        {
            _config = config;
            _auth = auth;
        }

        public async Task StartAsync(Func<string, Task> onMessage, CancellationToken token)
        {
            var random = new Random();

            while (!token.IsCancellationRequested)
            {
                var fakeMessage = JsonConvert.SerializeObject(new
                {
                    symbol = "AAPL",
                    price = random.Next(100, 200)
                });

                await onMessage(fakeMessage);

                await Task.Delay(2000, token);
            }
        }

        //public async Task StartAsync(Func<string, Task> onMessage, CancellationToken token)
        //{
        //    using var ws = new ClientWebSocket();

        //    var accessToken = await _auth.GetTokenAsync();

        //    ws.Options.SetRequestHeader("Authorization", $"Bearer {accessToken}");

        //    await ws.ConnectAsync(
        //        new Uri(_config["Fintacharts:Ws"]),
        //        token);

        //    // SUBSCRIBE (реальний формат приблизний)
        //    var subscribe = new
        //    {
        //        type = "subscribe",
        //        instruments = new[] { "EUR/USD" }
        //    };

        //    var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(subscribe));

        //    await ws.SendAsync(message, WebSocketMessageType.Text, true, token);

        //    var buffer = new byte[4096];

        //    while (!token.IsCancellationRequested)
        //    {
        //        var result = await ws.ReceiveAsync(buffer, token);

        //        var msg = Encoding.UTF8.GetString(buffer, 0, result.Count);

        //        await onMessage(msg);
        //    }
        //}
    }
}
