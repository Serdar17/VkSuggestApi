using System.Net;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Queries;

namespace WebApplication1.Infrastructure.VkMaps.Client;

public class CachedSearchGeocodingVkMapsClient : ISearchGeocodingVkMapsClient
{
    private readonly IMemoryCache _memoryCache;
    private readonly ISearchGeocodingVkMapsClient _client;

    public CachedSearchGeocodingVkMapsClient(IMemoryCache memoryCache, ISearchGeocodingVkMapsClient client)
    {
        _memoryCache = memoryCache;
        _client = client;
    }

    public async Task<HttpResponseMessage> SuggestAsync(GetSuggestQuery query)
    {
        var key = $"{query.Location}-{query.Limit}";
        if (!_memoryCache.TryGetValue(key, out Tuple<HttpStatusCode, string> tuple))
        {
            var response = await _client.SuggestAsync(query);
            var content = await response.Content.ReadAsStringAsync();
            tuple = Tuple.Create(response.StatusCode, content);
            _memoryCache.Set(key, tuple, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });
        }

        return new HttpResponseMessage(tuple.Item1) { Content = new StringContent(tuple.Item2) };
    }
}