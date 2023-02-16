using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;
using WebApplication1.Queries;

namespace WebApplication1.Service;

public class VkApiService : IVkApiService<BaseResponseDto>
{
    private readonly IMemoryCache _cache;
    private readonly IVkApiClient _service;

    public VkApiService(IMemoryCache cache, IVkApiClient service)
    {
        _cache = cache;
        _service = service;
    }
    
    public async Task<BaseResponseDto> GetSuggestIngoAsync(GetSuggestQuery query)
    {
        try
        {
            if (!_cache.TryGetValue(query.Location, out BaseResponseDto responseDto))
            {
                responseDto = await _service.ExecuteAsync(query);
                _cache.Set(query.Location, responseDto, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
            } 
            return responseDto;
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