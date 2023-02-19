using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;
using WebApplication1.Infrastructure.VkMaps.Services;
using WebApplication1.Queries;

namespace WebApplication1.Infrastructure.Services;

public class InterestAddressService : IInterestAddressService
{
    private readonly ISearchGeocodingVkMapsService _vkMapsService;

    public InterestAddressService(ISearchGeocodingVkMapsService vkMapsService)
    {
        _vkMapsService = vkMapsService;
    }

    public async Task<BaseResponseDto> SuggestAsync(GetSuggestQuery query)
    {
        return await _vkMapsService.Suggest(query);
    }

    public async Task<BaseResponseDto> PlacesAsync(GetPlacesQuery query)
    {
        return await _vkMapsService.Places(query);
    }

    public async Task<BaseResponseDto> SearchAsync(GetSearchQuery query)
    {
        return await _vkMapsService.Search(query);
    }
}