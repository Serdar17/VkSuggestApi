using Ardalis.Result;
using WebApplication1.Application.Queries.GetPlacesQuery;
using WebApplication1.Application.Queries.GetSearchQuery;
using WebApplication1.Application.Queries.GetSuggestQuery;
using WebApplication1.Dto;

namespace WebApplication1.Infrastructure.VkMaps.Services;

public interface ISearchGeocodingVkMapsService
{
    public Task<Result<SuccessResponse>> Suggest(GetSuggestQuery query);
    
    public Task<Result<SuccessResponse>> Places(GetPlacesQuery query);
    
    public Task<Result<SuccessResponse>> Search(GetSearchQuery query);
}