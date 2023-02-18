using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;

namespace WebApplication1.Queries;

public class GetSuggestQuery : IRequest<BaseResponseDto>
{
    [FromQuery] 
    [DefaultValue(5)]
    public int Limit { get; set; } = 5;
    
    [FromQuery]
    public string Location { get; set; }
}

public class GetSuggestQueryHandler : IRequestHandler<GetSuggestQuery, BaseResponseDto>
{
    private readonly IInterestAddressService _service;

    public GetSuggestQueryHandler(IInterestAddressService service)
    {
        _service = service;
    }
    
    public async Task<BaseResponseDto> Handle(GetSuggestQuery request, CancellationToken cancellationToken)
    {
        return await _service.SuggestAsync(request);
    }
}
