using WebApplication1.Dto.Entities;

namespace WebApplication1.Dto;

public class SuccessResponse : BaseResponse
{
    /// <summary>
    /// Строка запроса
    /// </summary>
    public string Request { get; set; }

    /// <summary>
    /// Список с найденными локациями
    /// </summary>
    public List<Location> Results { get; set; }
}