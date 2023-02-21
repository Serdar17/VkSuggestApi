using System.ComponentModel;
using Ardalis.Result;
using MediatR;
using WebApplication1.Dto;
using WebApplication1.Dto.Entities;

namespace WebApplication1.Application.Queries.GetSearchQuery;

public sealed class GetSearchQuery : IRequest<Result<SuccessResponse>>
{
    [DefaultValue(2)] 
    public int Limit { get; set; } = 2;
    
    [DefaultValue("")]
    public string Location { get; set;} = String.Empty; 
    
    [DefaultValue("address_details,pin")]
    public List<string> Fields { get; set; } = new() { "address_details", "pin" };
    
    public Coordinate Coordinate { get; set; }
}