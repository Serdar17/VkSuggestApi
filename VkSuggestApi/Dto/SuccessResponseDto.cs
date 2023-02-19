using System.Text.Json.Serialization;
using WebApplication1.Dto.Entities;

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