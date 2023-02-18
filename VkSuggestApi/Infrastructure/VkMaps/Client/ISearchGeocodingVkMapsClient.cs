using WebApplication1.Queries;

namespace WebApplication1.Infrastructure.VkMaps.Client;

public interface ISearchGeocodingVkMapsClient
{
    public Task<HttpResponseMessage> SuggestAsync(GetSuggestQuery query);
}