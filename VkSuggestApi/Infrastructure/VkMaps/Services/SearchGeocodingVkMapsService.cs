using WebApplication1.Dto;
using WebApplication1.Infrastructure.VkMaps.Client;
using WebApplication1.Queries;

namespace WebApplication1.Infrastructure.VkMaps.Services;

public class SearchGeocodingVkMapsService : ISearchGeocodingVkMapsService
{
    private readonly ISearchGeocodingVkMapsClient _client;

    public SearchGeocodingVkMapsService(ISearchGeocodingVkMapsClient client)
    {
        _client = client;
    }
    
    public async Task<BaseResponseDto> Suggest(GetSuggestQuery query)
    {
        try
        {
            var response = await _client.SuggestAsync(query);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadFromJsonAsync<SuggestResponse>();
            return responseAsString;
        }
        catch (HttpRequestException e)
        {
            return new ErrorResponseDto()
            {
                ErrorMessage = e.Message
            };
        }
    }
}