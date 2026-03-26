using MarketDataService.Domain.Entities;
using MarketDataService.DTOs;

namespace MarketDataService.Mapping
{
    public static class MappingExtensions
    {
        public static AssetDto ToDto(this Asset asset)
        {
            return new AssetDto
            {
                Id = asset.Id,
                Symbol = asset.Symbol,
                //Name = asset.Name
            };
        }

        public static PriceDto ToDto(this Price price)
        {
            return new PriceDto
            {
                Id = price.Id,
                AssetId = price.AssetId,
                Value = price.Value,
                UpdatedAt = price.UpdatedAt
            };
        }
    }
}
