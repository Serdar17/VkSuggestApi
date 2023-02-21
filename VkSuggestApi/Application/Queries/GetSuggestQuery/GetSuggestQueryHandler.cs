using Ardalis.Result;
using MediatR;
using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;

namespace WebApplication1.Application.Queries.GetSuggestQuery;

public sealed class GetSuggestQueryHandler : IRequestHandler<GetSuggestQuery, Result<SuccessResponse>>
{
    private readonly IInterestAddressService _service;

    public GetSuggestQueryHandler(IInterestAddressService service)
    {
        _service = service;
    }
    
    public async Task<Result<SuccessResponse>> Handle(GetSuggestQuery request, CancellationToken cancellationToken)
    {
        return await _service.SuggestAsync(request);
    }
}