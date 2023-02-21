using System.ComponentModel;
using Ardalis.Result;
using MediatR;
using WebApplication1.Dto;
using WebApplication1.Dto.Entities;

namespace WebApplication1.Application.Queries.GetPlacesQuery;

public sealed class GetPlacesQuery : IRequest<Result<SuccessResponse>>
{
    [DefaultValue(2)] 
    public int Limit { get; set; } = 2;
    
    [DefaultValue("")]
    public string Location { get; set;} = String.Empty; 
    
    [DefaultValue("address,name")] 
    public List<string> Fields { get; set; } = new() { "address", "name" };
    
    public Coordinate Coordinate { get; set; }
}