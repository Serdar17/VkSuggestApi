using Ardalis.Result;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Application.Helpers;
using WebApplication1.Application.Queries;
using WebApplication1.Dto;

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

    public async Task<Result<SuccessResponse>> Suggest(GetSuggestQuery query)
    {
        var cacheKey = CacheKeyHelper.GetUniqueKeyAsString(PathByMethods.PathToSuggest, query);
        return (await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return await _service.Suggest(query);
        }))!;
    }

    public async Task<Result<SuccessResponse>> Places(GetPlacesQuery query)
    {
        var cacheKey = CacheKeyHelper.GetUniqueKeyAsString(PathByMethods.PathToPlaces, query.Fields);
        return (await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return await _service.Places(query);
        }))!;
    }

    public async Task<Result<SuccessResponse>> Search(GetSearchQuery query)
    {
        var cacheKey = CacheKeyHelper.GetUniqueKeyAsString(PathByMethods.PathToSearch, query);
        return (await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return await _service.Search(query);
        }))!;
    }
}