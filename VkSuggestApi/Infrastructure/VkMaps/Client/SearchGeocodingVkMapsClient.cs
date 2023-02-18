using Microsoft.Extensions.Options;
using WebApplication1.Options;
using WebApplication1.Queries;

namespace WebApplication1.Infrastructure.VkMaps.Client;

public class SearchGeocodingVkMapsClient : ISearchGeocodingVkMapsClient
{
    private readonly HttpClient _httpClient;
    private readonly VkApiSetting _apiSetting;

    public SearchGeocodingVkMapsClient(HttpClient httpClient, IOptions<VkApiSetting> options)
    {
        _httpClient = httpClient;
        _apiSetting = options.Value;
    }

    public async Task<HttpResponseMessage> SuggestAsync(GetSuggestQuery query)
    {
        var uri = new Uri($"{_apiSetting.BaseUrl}/suggest?limit={query.Limit}&q={query.Location}");
        var httpResponseMessage = await _httpClient.GetAsync(uri);
        return httpResponseMessage;
    }
}