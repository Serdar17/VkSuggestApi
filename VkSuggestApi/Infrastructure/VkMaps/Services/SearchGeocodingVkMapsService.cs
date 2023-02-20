using Ardalis.Result;
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
    
    public async Task<Result<SuccessResponse>> Suggest(GetSuggestQuery query)
    {
        var response = await _client.SuggestAsync(query.Fields.ToArray(), query.Location, query.Limit);
        var result = await ParseResponse<SuccessResponse>(response);
        return result;
    }

    public async Task<Result<SuccessResponse>> Places(GetPlacesQuery query)
    {
        var response = await _client.PlacesAsync(query.Fields.ToArray(), query.Coordinate.Lat, query.Coordinate.Lon,
            query.Location, query.Limit);
        var result = await ParseResponse<SuccessResponse>(response);
        return result;
    }

    public async Task<Result<SuccessResponse>> Search(GetSearchQuery query)
    {
        var response = await _client.SearchAsync(query.Fields.ToArray(), query.Coordinate.Lat, query.Coordinate.Lon,
            query.Location, query.Limit);
        var result = await ParseResponse<SuccessResponse>(response);
        return result;
    }

    private async Task<Result<TResponse>> ParseResponse<TResponse>(HttpResponseMessage response)
        where TResponse : BaseResponseDto
    {
        try
        {
            response.EnsureSuccessStatusCode();
            var successResponse = await response.Content.ReadFromJsonAsync<TResponse>();
            return Result.Success(successResponse);
        }
        catch (HttpRequestException e)
        {
            var errorResponse =  new ErrorResponseDto()
            {
                ErrorMessage = e.Message
            };
            return Result.Error(errorResponse.ErrorMessage);
        }
    }
}