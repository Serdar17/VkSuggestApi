namespace WebApplication1.Options;

public sealed class VkMapsApiSetting
{
    public static string Section = "VkMapsApi";

    public string BaseUrl { get; set; } = string.Empty;
    
    public string PathToSuggest { get; set; } = string.Empty;
    
    public string PathToPlaces { get; set; } = string.Empty;
    
    public string PathToSearch { get; set; } = string.Empty;
}