using System.ComponentModel;
using Ardalis.Result;
using MediatR;
using WebApplication1.Dto;

namespace WebApplication1.Application.Queries.GetSuggestQuery;

public sealed class GetSuggestQuery : IRequest<Result<SuccessResponse>>
{
    [DefaultValue(5)]
    public int Limit { get; set; } = 5;
    
    public string Location { get; set; }
    
    [DefaultValue("address,name")] 
    public List<string> Fields { get; set; } = new() { "address", "name" };
}