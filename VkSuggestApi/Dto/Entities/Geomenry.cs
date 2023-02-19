using System.Text.Json.Serialization;

namespace WebApplication1.Dto.Entities;

public class Geometry
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<List<List<double>>> Coordinates { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Type { get; set; }
}