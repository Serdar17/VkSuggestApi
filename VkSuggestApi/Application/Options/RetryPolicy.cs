using System.Net;
using Polly;

namespace WebApplication1.Options;

public static class RetryPolicy
{
    public static int MaxRetries = 5;
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .OrResult(x => x.StatusCode != HttpStatusCode.OK)
            .WaitAndRetryAsync(MaxRetries, attempt => TimeSpan.FromMilliseconds(100 * attempt));
    }
}