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
            var response = await _client.SuggestAsync(query.Fields.ToArray(), query.Location, query.Limit);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SuggestResponse>();
        }
        catch (HttpRequestException e)
        {
            return new ErrorResponseDto()
            {
                ErrorMessage = e.Message
            };
        }
    }

    public async Task<BaseResponseDto> Places(GetPlacesQuery query)
    {
        try
        {
            var response = await _client.PlacesAsync(query.Fields.ToArray(), query.Coordinate.Lat, query.Coordinate.Lon,
                query.LocationName, query.Limit);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PlacesResponseDto>();
        }
        catch (HttpRequestException e)
        {
            return new ErrorResponseDto()
            {
                ErrorMessage = e.Message
            };
        }
    }

    public async Task<BaseResponseDto> Search(GetSearchQuery query)
    {
        try
        {
            var response = await _client.SearchAsync(query.Fields.ToArray(), query.Coordinate.Lat, query.Coordinate.Lon,
                query.LocationName, query.Limit);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SearchResponseDto>();
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