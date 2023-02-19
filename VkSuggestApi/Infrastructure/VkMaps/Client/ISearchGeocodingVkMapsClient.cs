
namespace WebApplication1.Infrastructure.VkMaps.Client;

public interface ISearchGeocodingVkMapsClient
{
    public Task<HttpResponseMessage> SuggestAsync(string[] fields, string location, int limit);
    
    public Task<HttpResponseMessage> PlacesAsync(string[] fields, double lat, double lon, string locationName, int limit);
    
    public Task<HttpResponseMessage> SearchAsync(string[] fields, double lat, double lon, string locationName, int limit);
}