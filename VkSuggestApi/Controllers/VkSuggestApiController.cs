using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Queries;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VkSuggestApiController : ControllerBase
{
    private readonly IMediator _mediator;

    public VkSuggestApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Возвращает информацию по аддресам и местам интереса из https://demo.maps.vk.com/api/suggest
    /// </summary>
    /// <param name="limit">Число объектов в моделе</param>
    /// <param name="suggest">Тело поискового запроса</param>
    /// <returns>Возвращает объект ResponseDto с данными об аддресам и местам интереса</returns>
    /// [Range(1, 100), FromQuery] int limit, [FromQuery] string suggest
    [HttpGet]
    [ProducesResponseType(typeof(SuccessResponseDto), StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<IActionResult> Get([FromQuery] GetSuggestQuery query)
    {
        var response = await _mediator.Send(query);
        if (response is ErrorResponseDto errorResponse)
            return new BadRequestObjectResult(errorResponse);
        return new JsonResult(response);
    }
}