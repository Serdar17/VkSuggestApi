using System.Text.Json.Serialization;

namespace WebApplication1.Dto;

public class SuggestResponse : BaseResponseDto
{
    /// <summary>
    /// Строка запроса
    /// </summary>
    public string Request { get; set; }

    /// <summary>
    /// Список с найденными локациями
    /// </summary>
    [JsonPropertyName("results")]
    public List<Location> Locations { get; set; }
}

public class Location
{
    /// <summary>
    /// Полный найденный адрес
    /// </summary>
    public string Address { get; set; }
    
    /// <summary>
    /// Название найденного объекта
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }
    
    /// <summary>
    /// Тип найденного объекта
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Type { get; set; }
}