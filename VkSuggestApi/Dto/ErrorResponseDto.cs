using System.Net;

namespace WebApplication1.Dto;

public class ErrorResponseDto : BaseResponseDto
{
    public string ErrorMessage { get; set; }
    
}