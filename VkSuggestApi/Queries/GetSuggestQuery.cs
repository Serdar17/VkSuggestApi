using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;

namespace WebApplication1.Queries;

public class GetSuggestQuery : IRequest<BaseResponseDto>
{
    [DefaultValue(5)]
    public int Limit { get; set; } = 5;
    
    public string Location { get; set; }
    
    [DefaultValue("address,name")] 
    public List<string> Fields { get; set; } = new() { "address", "name" };

    public override string ToString()
    {
        return $"{Limit}-{Location}-{String.Join(',', Fields)}";
    }
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
