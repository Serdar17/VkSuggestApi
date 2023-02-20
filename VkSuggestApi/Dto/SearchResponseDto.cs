using WebApplication1.Dto.Entities;

namespace WebApplication1.Dto;

public class SearchResponseDto : BaseResponseDto
{
    public string Request { get; set; }
    
    public List<Location> Results { get; set; }
}