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
    [JsonPropertyName("address_details")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AddressDetail AddressDetail { get; set; }
    
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
    
    /// <summary>
    /// Идентификатор найденного объекта
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Ref { get; set; }
}