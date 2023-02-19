using WebApplication1.Dto;
using WebApplication1.Queries;

namespace WebApplication1.Infrastructure.VkMaps.Services;

public interface ISearchGeocodingVkMapsService
{
    public Task<BaseResponseDto> Suggest(GetSuggestQuery query);
    
    public Task<BaseResponseDto> Places(GetPlacesQuery query);
    
    public Task<BaseResponseDto> Search(GetSearchQuery query);
}