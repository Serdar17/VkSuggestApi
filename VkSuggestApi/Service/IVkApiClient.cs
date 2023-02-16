using WebApplication1.Dto;
using WebApplication1.Queries;

namespace WebApplication1.Service;

public interface IVkApiClient
{
    public Task<BaseResponseDto> ExecuteAsync(GetSuggestQuery query);
}