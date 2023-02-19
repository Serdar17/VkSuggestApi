﻿using WebApplication1.Dto;
using WebApplication1.Queries;

namespace WebApplication1.Application.Interfaces;

public interface IInterestAddressService
{
    public Task<BaseResponseDto> SuggestAsync(GetSuggestQuery query);
    
    public Task<BaseResponseDto> PlacesAsync(GetPlacesQuery query);
    
    public Task<BaseResponseDto> SearchAsync(GetSearchQuery query);
}