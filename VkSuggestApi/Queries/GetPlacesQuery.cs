using System.ComponentModel;
using MediatR;
using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;

namespace WebApplication1.Queries;

public class GetPlacesQuery : IRequest<BaseResponseDto>
{
    [DefaultValue(2)] 
    public int Limit { get; set; } = 2;
    
    [DefaultValue("")]
    public string LocationName { get; set;} = String.Empty; 
    
    [DefaultValue("address,name")] 
    public List<string> Fields { get; set; } = new() { "address", "name" };
    
    public Coordinate Coordinate { get; set; }

    public override string ToString()
    {
        return $"{Limit}-{LocationName}-{Coordinate.Lat}-{Coordinate.Lon}-{String.Join(',', Fields)}";
    }
}

public class GetPlacesQueryHandler : IRequestHandler<GetPlacesQuery, BaseResponseDto>
{
    private readonly IInterestAddressService _service;

    public GetPlacesQueryHandler(IInterestAddressService service)
    {
        _service = service;
    }
    
    public async Task<BaseResponseDto> Handle(GetPlacesQuery query, CancellationToken cancellationToken)
    {
        return await _service.PlacesAsync(query);
    }
}