using WebApplication1.Dto;
using WebApplication1.Queries;

namespace WebApplication1.Service;

public class VkApiClient : IVkApiClient
{
    private readonly HttpClient _httpClient;

    public VkApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<BaseResponseDto> ExecuteAsync(GetSuggestQuery query)
    {
        var uri = new Uri($"{_httpClient.BaseAddress}?limit={query.Limit}&q={query.Location}");
        using var httpResponseMessage = await _httpClient.GetAsync(uri);
        httpResponseMessage?.EnsureSuccessStatusCode();
        return await httpResponseMessage.Content.ReadFromJsonAsync<SuccessResponseDto>();
    }
}