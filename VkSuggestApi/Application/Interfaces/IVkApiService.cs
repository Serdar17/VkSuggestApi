using WebApplication1.Dto;
using WebApplication1.Queries;

namespace WebApplication1.Application.Interfaces;

public interface IVkApiService<T>
{
    public Task<T> GetSuggestIngoAsync(GetSuggestQuery query);
}