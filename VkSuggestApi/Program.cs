using MediatR;
using Serilog;
using Serilog.Events;
using WebApplication1.Application.Interfaces;
using WebApplication1.Infrastructure.Services;
using WebApplication1.Infrastructure.VkMaps.Client;
using WebApplication1.Infrastructure.VkMaps.Services;
using WebApplication1.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IInterestAddressService, InterestAddressService>();
builder.Services.AddScoped<ISearchGeocodingVkMapsService, SearchGeocodingVkMapsService>();

builder.Services.Configure<VkApiSetting>(builder.Configuration.GetSection(VkApiSetting.Section));
builder.Services.AddHttpClient<ISearchGeocodingVkMapsClient, SearchGeocodingVkMapsClient>()
    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
    .AddPolicyHandler(RetryPolicy.GetRetryPolicy());

builder.Services.Decorate<ISearchGeocodingVkMapsClient, CachedSearchGeocodingVkMapsClient>();

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMemoryCache();

builder.Host.UseSerilog((cts, lc) => 
    lc
        .Enrich.FromLogContext()
        .WriteTo.Console(
            LogEventLevel.Information,
            outputTemplate:
            "{Timestamp:HH:mm:ss:ms} LEVEL:[{Level}]| THREAD:|{ThreadId}| Source: |{Source}| {Message}{NewLine}{Exception}"));

// var logger = new LoggerConfiguration()
//     .ReadFrom.Configuration(builder.Configuration)
//     .CreateLogger();
//
// builder.Logging.ClearProviders();
// builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }