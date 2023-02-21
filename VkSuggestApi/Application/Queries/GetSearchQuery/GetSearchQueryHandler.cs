using Ardalis.Result;
using MediatR;
using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;

namespace WebApplication1.Application.Queries.GetSearchQuery;

public sealed class GetSearchQueryHandler : IRequestHandler<GetSearchQuery, Result<SuccessResponse>>
{
    private readonly IInterestAddressService _service;

    public GetSearchQueryHandler(IInterestAddressService service)
    {
        _service = service;
    }
    
    public async Task<Result<SuccessResponse>> Handle(GetSearchQuery query, CancellationToken cancellationToken)
    {
        return await _service.SearchAsync(query);
    }
}