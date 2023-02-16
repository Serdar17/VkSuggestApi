using System.Net;
using Polly;
using Polly.Extensions.Http;

namespace WebApplication1.Options;

public static class RetryPolicy
{
    public static int MaxRetries = 5;
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode != HttpStatusCode.OK)
            .WaitAndRetryAsync(MaxRetries, attempt => TimeSpan.FromMilliseconds(100 * attempt));
    }
}