using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Json;
using System.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using WebApplication1.Dto;

namespace VkSuggestApi.Tests;

public class VkMapsApiControllerTests
{
    private WebApplicationFactory<Program> _webHost;
    private HttpClient _client;
    
    [SetUp]
    public void SetUp()
    {
        _webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
        _client = _webHost.CreateClient();
    }

    [TestCase("api/VkMapsApi/suggest", HttpStatusCode.OK)]
    public async Task CheckStatus_SendRequest_ShouldReturnOk(string path, HttpStatusCode statusCode)
    {
        var uri = new Uri(_client.BaseAddress, $"{path}?Limit=1&Location=Мск");

        var response = await _client.GetAsync(uri);
        
        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
    }
    
    [TestCase("api/VkMapsApi/suggest", 3, "Москва Ленинский 12")]
    public async Task CheckLocationData_SendRequestToSuggest_ShouldReturnActualLocationsData(string path, int limit, string location)
    {
        
        var uri = new Uri(_client.BaseAddress, $"{path}?Limit={limit}&Location={location}");

        var response = await _client.GetAsync(uri);
        var responseMessage = await response.Content.ReadFromJsonAsync<SuccessResponse>();

        Assert.IsTrue(responseMessage.Results.Count <= limit);
    }
    
    [TestCase("api/VkMapsApi/suggest", 1, "", HttpStatusCode.BadRequest)]
    public async Task CheckQueryParams_SendRequest_ShouldReturnBadRequest(string path, int limit, 
        string location, HttpStatusCode statusCode)
    {
        var uri = new Uri(_client.BaseAddress, $"{path}?Limit={limit}&Location={location}");
        
        var response = await _client.GetAsync(uri);

        Assert.That(response.StatusCode, Is.EqualTo(statusCode));
    }
}