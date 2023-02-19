﻿using System.Collections.Specialized;
using System.Web;
using Microsoft.Extensions.Options;
using WebApplication1.Options;

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

    public async Task<HttpResponseMessage> SuggestAsync(string[] fields, string location, int limit)
    {
        var uriBuilder = new UriBuilder($"{_apiSetting.BaseUrl}/suggest");
        var parameters = GetNameValueCollectionByParameters(fields, location, limit);
        uriBuilder.Query = parameters.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
        var httpResponseMessage = await _httpClient.SendAsync(request);
        return httpResponseMessage;
    }

    public async Task<HttpResponseMessage> PlacesAsync(string[] fields, string location, string locationName, int limit)
    {
        var uriBuilder = new UriBuilder($"{_apiSetting.BaseUrl}/places");
        var parameters = GetNameValueCollectionByParameters(fields, location, limit);
        parameters.Add("location", locationName);
        uriBuilder.Query = parameters.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
        var httpResponseMessage = await _httpClient.SendAsync(request);
        return httpResponseMessage;
    }

    public async Task<HttpResponseMessage> SearchAsync(string[] fields, string location, string locationName, int limit)
    {
        var uriBuilder = new UriBuilder($"{_apiSetting.BaseUrl}/search");
        var parameters = GetNameValueCollectionByParameters(fields, locationName, limit);
        parameters.Add("location", location);
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