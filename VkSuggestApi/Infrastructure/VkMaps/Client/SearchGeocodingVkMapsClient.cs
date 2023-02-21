using System.Collections.Specialized;
using System.Web;
using Microsoft.Extensions.Options;
using WebApplication1.Options;

namespace WebApplication1.Infrastructure.VkMaps.Client;

public class SearchGeocodingVkMapsClient : ISearchGeocodingVkMapsClient
{
    private readonly HttpClient _httpClient;
    private readonly VkMapsApiSetting _apiSetting;

    public SearchGeocodingVkMapsClient(HttpClient httpClient, IOptions<VkMapsApiSetting> options)
    {
        _httpClient = httpClient;
        _apiSetting = options.Value;
    }

    public async Task<HttpResponseMessage> SuggestAsync(string[] fields, string location, int limit)
    {
        var uriBuilder = new UriBuilder($"{_apiSetting.BaseUrl}/{_apiSetting.PathToSuggest}");
        var parameters = GetNameValueCollectionByParameters(fields, location, limit);
        uriBuilder.Query = parameters.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
        var httpResponseMessage = await _httpClient.SendAsync(request);
        return httpResponseMessage;
    }

    public async Task<HttpResponseMessage> PlacesAsync(string[] fields, double lat, double lon, string locationName, int limit)
    {
        var uriBuilder = new UriBuilder($"{_apiSetting.BaseUrl}/{_apiSetting.PathToPlaces}");
        var parameters = GetNameValueCollectionByParameters(fields, locationName, limit);
        if (lat != 0 || lon != 0)
            parameters.Add("location", $"{lat},{lon}");
        uriBuilder.Query = parameters.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
        var httpResponseMessage = await _httpClient.SendAsync(request);
        return httpResponseMessage;
    }

    public async Task<HttpResponseMessage> SearchAsync(string[] fields, double lat, double lon, string locationName, int limit)
    {
        var uriBuilder = new UriBuilder($"{_apiSetting.BaseUrl}/{_apiSetting.PathToSearch}");
        var parameters = GetNameValueCollectionByParameters(fields, locationName, limit);
        if (lat != 0 || lon != 0)
            parameters.Add("location", $"{lat},{lon}");
        uriBuilder.Query = parameters.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
        var httpResponseMessage = await _httpClient.SendAsync(request);
        return httpResponseMessage;
    }

    private NameValueCollection GetNameValueCollectionByParameters (string[] fields, string location, int limit)
    {
        var parameters = HttpUtility.ParseQueryString(string.Empty);
        parameters.Add("fields", String.Join(',', fields));
        parameters.Add("limit", limit.ToString());
        parameters.Add("q", location);
        return parameters;
    }
}