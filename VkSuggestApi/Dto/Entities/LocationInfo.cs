using System.Text.Json.Serialization;

namespace WebApplication1.Dto.Entities;

public class LocationInfo
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Address { get; set; }
    
    [JsonPropertyName("address_details")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AddressDetail AddressDetail { get; set; }

    [JsonPropertyName("bbox")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<double> Bbox { get; set; }
    
    [JsonPropertyName("geometry")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry Geometry { get; set; }

    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<double> Pin { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Type { get; set; }
}