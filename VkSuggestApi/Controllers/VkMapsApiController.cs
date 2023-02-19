using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Queries;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VkMapsApiController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<VkMapsApiController> _logger;

    public VkMapsApiController(IMediator mediator, ILogger<VkMapsApiController> logger)
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
    [HttpGet("suggest")]
    [ProducesResponseType(typeof(SuggestResponse), StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<IActionResult> Suggest([FromQuery] GetSuggestQuery query)
    {
        var response = await _mediator.Send(query);
        if (response is ErrorResponseDto errorResponse)
            return new BadRequestObjectResult(errorResponse);
        
        _logger.LogInformation("Requested addresses and places of interest for {Location} in quantity" +
                               " {Limit}. The response is {@response} ", 
            query.Location, query.Limit, response);
        
        return new JsonResult(response);
    }
    
    [HttpGet("places")]
    [ProducesResponseType(typeof(PlacesResponseDto), StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<IActionResult> Places([FromQuery] GetPlacesQuery query)
    {
        var response = await _mediator.Send(query);
        if (response is ErrorResponseDto errorResponse)
            return new BadRequestObjectResult(errorResponse);
        
        _logger.LogInformation("Requested places and additional information for {Location} in quantity" +
                               " {Limit}. The response is {@response} ", 
            query.LocationName, query.Limit, response);
        
        return new JsonResult(response);
    }
    
    [HttpGet("search")]
    [ProducesResponseType(typeof(SearchResponseDto), StatusCodes.Status200OK)]
    [Produces("application/json")]
    public async Task<IActionResult> Search([FromQuery] GetSearchQuery query)
    {
        var response = await _mediator.Send(query);
        if (response is ErrorResponseDto errorResponse)
            return new BadRequestObjectResult(errorResponse);
        
        _logger.LogInformation("Requested geocoding for {Location} in quantity" +
                               " {Limit}. The response is {@response} ", 
            query.LocationName, query.Limit, response);
        
        return new JsonResult(response);
    }
}