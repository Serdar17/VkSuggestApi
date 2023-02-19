using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Dto;
using WebApplication1.Helper;
using WebApplication1.Queries;

namespace WebApplication1.Infrastructure.VkMaps.Services;

public class CachedSearchGeocodingVkMapsService : ISearchGeocodingVkMapsService
{
    private readonly ISearchGeocodingVkMapsService _service;
    private readonly IMemoryCache _memoryCache;

    public CachedSearchGeocodingVkMapsService(ISearchGeocodingVkMapsService service, IMemoryCache cache)
    {
        _service = service;
        _memoryCache = cache;
    }

    public async Task<BaseResponseDto?> Suggest(GetSuggestQuery query)
    {
        var cacheKey = new CacheKeyHelper("VkSuggestApi/InterestAddress/CachedSearchGeocodingVkMaps/Suggest",
            query);
        return await _memoryCache.GetOrCreateAsync(cacheKey.GetUniqueKeyAsString(), async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return await _service.Suggest(query);
        });
    }

    public async Task<BaseResponseDto?> Places(GetPlacesQuery query)
    {
        var cacheKey = new CacheKeyHelper("VkSuggestApi/InterestAddress/CachedSearchGeocodingVkMaps/Places",
            query.Fields);
        return await _memoryCache.GetOrCreateAsync(cacheKey.GetUniqueKeyAsString(), async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return await _service.Places(query);
        });
    }

    public async Task<BaseResponseDto?> Search(GetSearchQuery query)
    {
        var cacheKey = new CacheKeyHelper("VkSuggestApi/InterestAddress/CachedSearchGeocodingVkMaps/Search",
            query);
        return await _memoryCache.GetOrCreateAsync(cacheKey.GetUniqueKeyAsString(), async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return await _service.Search(query);
        });
    }
}