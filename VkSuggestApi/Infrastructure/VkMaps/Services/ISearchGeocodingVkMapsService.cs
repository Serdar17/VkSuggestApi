using WebApplication1.Dto;
using WebApplication1.Queries;

namespace WebApplication1.Infrastructure.VkMaps.Services;

public interface ISearchGeocodingVkMapsService
{
    public Task<BaseResponseDto> Suggest(GetSuggestQuery query);
}