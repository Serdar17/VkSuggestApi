
namespace WebApplication1.Infrastructure.VkMaps.Client;

public interface ISearchGeocodingVkMapsClient
{
    public Task<HttpResponseMessage> SuggestAsync(string[] fields, string location, int limit);
    
    public Task<HttpResponseMessage> PlacesAsync(string[] fields, string location, string locationName, int limit);
    
    public Task<HttpResponseMessage> SearchAsync(string[] fields, string location, string locationName, int limit);
}