using System.ComponentModel;
using MediatR;
using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;

namespace WebApplication1.Queries;

public class GetSearchQuery : IRequest<BaseResponseDto>
{
    [DefaultValue(2)] 
    public int Limit { get; set; } = 2;
    
    [DefaultValue("")]
    public string LocationName { get; set;} = String.Empty; 
    
    [DefaultValue("address_details,pin")] 
    public List<string> Fields { get; set; } = new() { "address_details", "pin" };

    [DefaultValue("")] 
    public string Location { get; set; } = String.Empty;

    public override string ToString()
    {
        return $"{Limit}-{LocationName}-{Location}-{String.Join(',', Fields)}";
    }
}

public class GetSearchQueryHandler : IRequestHandler<GetSearchQuery, BaseResponseDto>
{
    private readonly IInterestAddressService _service;

    public GetSearchQueryHandler(IInterestAddressService service)
    {
        _service = service;
    }
    
    public async Task<BaseResponseDto> Handle(GetSearchQuery query, CancellationToken cancellationToken)
    {
        return await _service.SearchAsync(query);
    }
}