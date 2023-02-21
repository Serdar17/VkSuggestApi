using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Queries;
using WebApplication1.Dto;

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
    [TranslateResultToActionResult]
    [HttpGet("suggest")]
    [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status200OK)]
    public async Task<Result<SuccessResponse>> Suggest([FromQuery] GetSuggestQuery query)
    {
        var response = await _mediator.Send(query);
        if (response is null)
            return Result<SuccessResponse>.NotFound();
        
        _logger.LogInformation("Requested addresses and places of interest for {Location} in quantity" +
                               " {Limit}. The response is {@response} ", 
            query.Location, query.Limit, response);
        
        return response;
    }
    
    [TranslateResultToActionResult]
    [HttpGet("places")]
    [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status200OK)]
    public async Task<Result<SuccessResponse>> Places([FromQuery] GetPlacesQuery query)
    {
        var response = await _mediator.Send(query);
        if (response is null)
            return Result<SuccessResponse>.NotFound();
        
        _logger.LogInformation("Requested places and additional information for {Location} in quantity" +
                               " {Limit}. The response is {@response} ", 
            query.Location, query.Limit, response);
        
        return response;
    }
    
    [TranslateResultToActionResult]
    [HttpGet("search")]
    [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status200OK)]
    public async Task<Result<SuccessResponse>> Search([FromQuery] GetSearchQuery query)
    {
        var response = await _mediator.Send(query);
        if (response is null)
            return Result<SuccessResponse>.NotFound();
        
        _logger.LogInformation("Requested geocoding for {Location} in quantity" +
                               " {Limit}. The response is {@response} ", 
            query.Location, query.Limit, response);
        
        return response;
    }
}