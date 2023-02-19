using System.Net;
using Microsoft.Extensions.Caching.Memory;
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

    public async Task<HttpResponseMessage> SuggestAsync(string[] fields, string location, int limit)
    {
        var key = $"{string.Join(',', fields)}-{location}-{limit}";
        if (!_memoryCache.TryGetValue(key, out Tuple<HttpStatusCode, string> tuple))
        {
            var response = await _client.SuggestAsync(fields, location, limit);
            var content = await response.Content.ReadAsStringAsync();
            tuple = Tuple.Create(response.StatusCode, content);
            _memoryCache.Set(key, tuple, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            });
        }

        return new HttpResponseMessage(tuple.Item1) { Content = new StringContent(tuple.Item2) };
    }

    public Task<HttpResponseMessage> PlacesAsync(string[] fields, double lat, double lon, string locationName, int limit)
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> SearchAsync(string[] fields, double lat, double lon, string locationName, int limit)
    {
        throw new NotImplementedException();
    }
}