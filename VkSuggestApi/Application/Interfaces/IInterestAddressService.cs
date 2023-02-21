﻿using Ardalis.Result;
using WebApplication1.Application.Queries;
using WebApplication1.Dto;

namespace WebApplication1.Application.Interfaces;

public interface IInterestAddressService
{
    public Task<Result<SuccessResponse>> SuggestAsync(GetSuggestQuery query);
    
    public Task<Result<SuccessResponse>> PlacesAsync(GetPlacesQuery query);
    
    public Task<Result<SuccessResponse>> SearchAsync(GetSearchQuery query);
}