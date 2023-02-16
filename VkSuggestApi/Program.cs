using MediatR;
using WebApplication1;
using WebApplication1.Application.Interfaces;
using WebApplication1.Dto;
using WebApplication1.Options;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IVkApiService<BaseResponseDto>, VkApiService>();
var options = builder.Configuration.GetSection(nameof(VkApiOption))
    .Get<VkApiOption>();

builder.Services.AddHttpClient<IVkApiClient, VkApiClient>(config =>
{
    config.BaseAddress = new Uri(options.BaseAddress);
    config.DefaultRequestHeaders.Clear();
})
    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
    .AddPolicyHandler(RetryPolicy.GetRetryPolicy());

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();