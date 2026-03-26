using MarketDataService.Background;
using MarketDataService.Infrastructure.Fintacharts;
using MarketDataService.Infrastructure.Persistence;
using MarketDataService.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=market.db"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthClient>();
builder.Services.AddScoped<FintachartsRestClient>();
builder.Services.AddScoped<FintachartsWebSocketClient>();

builder.Services.AddScoped<AssetService>();
builder.Services.AddScoped<PriceService>();

builder.Services.AddHostedService<PriceUpdaterHostedService>();

builder.Services.AddHttpClient<AuthClient>(client =>
{
    client.BaseAddress = new Uri("https://platform.fintacharts.com");
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
