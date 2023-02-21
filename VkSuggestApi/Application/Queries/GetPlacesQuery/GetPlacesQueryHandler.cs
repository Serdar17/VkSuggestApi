using Ardalis.Result;
using MediatR;
using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;

namespace WebApplication1.Application.Queries.GetPlacesQuery;

public sealed class GetPlacesQueryHandler : IRequestHandler<GetPlacesQuery, Result<SuccessResponse>>
{
    private readonly IInterestAddressService _service;

    public GetPlacesQueryHandler(IInterestAddressService service)
    {
        _service = service;
    }
    
    public async Task<Result<SuccessResponse>> Handle(GetPlacesQuery query, CancellationToken cancellationToken)
    {
        return await _service.PlacesAsync(query);
    }
}