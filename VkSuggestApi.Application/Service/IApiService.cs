namespace VkSuggestApi.Application.Service;

public interface IApiService<T>
{
    public Task<T> ExecuteAsync();
}