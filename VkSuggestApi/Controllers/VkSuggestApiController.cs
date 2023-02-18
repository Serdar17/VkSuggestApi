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
    private readonly ILogger<VkSuggestApiController> _logger;

    public VkSuggestApiController(IMediator mediator, ILogger<VkSuggestApiController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    /// <summary>
    /// Возвращает информацию по аддресам и местам интереса из https://demo.maps.vk.com/api/suggest
    /// </summary>
    /// <param name="limit">Число объектов в моделе</param>
    /// <param name="suggest">Тело поискового запроса</param>
    /// <returns>Возвращает объект ResponseDto с данными об аддресам и местам интереса</returns>
    [HttpGet]
    [ProducesResponseType(typeof(SuggestResponse), StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<IActionResult> Get([FromQuery] GetSuggestQuery query)
    {
        var response = await _mediator.Send(query);
        if (response is ErrorResponseDto errorResponse)
            return new BadRequestObjectResult(errorResponse);
        
        _logger.LogInformation("requested addresses and places of interest for {Location} in quantity" +
                               " {Limit}. The response is {@response} ", 
            query.Location, query.Limit, response);
        
        return new JsonResult(response);
    }
}