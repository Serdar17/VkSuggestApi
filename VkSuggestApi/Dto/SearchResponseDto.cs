using WebApplication1.Dto.Entities;

namespace WebApplication1.Dto;

public class SearchResponseDto : BaseResponseDto
{
    public string Request { get; set; }
    
    public List<LocationInfo> Results { get; set; }
}