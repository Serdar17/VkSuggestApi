using System.Text.Json.Serialization;

namespace WebApplication1.Dto.Entities;

public class Location
{
    /// <summary>
    /// Полный найденный адрес
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Address { get; set; }
    
    /// <summary>
    /// Детальная информация о найденном адресе
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("address_details")]
    public AddressDetail AddressDetail { get; set; }
    
    /// <summary>
    /// Название найденного объекта
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }
    
    /// <summary>
    /// Границы местонахождения найденного объекта для позиционирования на карте
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<double> Bbox { get; set; }
    
    /// <summary>
    /// Геометрия найденного объекта
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry Geometry { get; set; }
    
    /// <summary>
    /// Тип найденного объекта
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Type { get; set; }
    
    /// <summary>
    /// Идентификатор найденного объекта
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Ref { get; set; }
    
    /// <summary>
    /// Информация о входах в здание.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Entrance Entrance { get; set; }

    /// <summary>
    /// Координаты найденного объекта (долгота и широта)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<double> Pin { get; set; }
}