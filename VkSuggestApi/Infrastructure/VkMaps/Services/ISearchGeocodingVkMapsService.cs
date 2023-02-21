using Ardalis.Result;
using WebApplication1.Application.Queries;
using WebApplication1.Dto;

namespace WebApplication1.Infrastructure.VkMaps.Services;

public interface ISearchGeocodingVkMapsService
{
    public Task<Result<SuccessResponse>> Suggest(GetSuggestQuery query);
    
    public Task<Result<SuccessResponse>> Places(GetPlacesQuery query);
    
    public Task<Result<SuccessResponse>> Search(GetSearchQuery query);
}