using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text;

namespace MyOrder.Infrastructure.HttpHandlers;

public class ApiMetricsHandler(ILogger<ApiMetricsHandler> logger) : DelegatingHandler
{
    private readonly ILogger<ApiMetricsHandler> _logger = logger
        ?? throw new ArgumentNullException(nameof(logger));
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        string content = request.Content is not null && request.Method == HttpMethod.Post
            ? await request.Content.ReadAsStringAsync(cancellationToken)
            : string.Empty;

        if (!string.IsNullOrEmpty(content))
        {
            _logger.LogDebug("Outgoing request\n" +
           "Method: {Method}\n" +
           "Url: {Url}\n" +
           "Body:\n{Body}", request.Method, request.RequestUri?.AbsoluteUri, content);

        }
        else
        {
            _logger.LogDebug("Outgoing request\n" +
           "Method: {Method}\n" +
           "Url: {Url}", request.Method, request.RequestUri?.AbsoluteUri);
        }


        var stopwatch = Stopwatch.StartNew();
        var response = await base.SendAsync(request, cancellationToken);
        stopwatch.Stop();
        _logger.LogDebug("Request {Method} {Uri} took {ElapsedMilliseconds} ms.",
            request.Method, request.RequestUri?.AbsolutePath, stopwatch.ElapsedMilliseconds);

        //if (response.Content != null)
        //{
        //    string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        //    _logger.LogDebug("Response content :\n" +
        //        "{response}", responseContent);
        //}
        return response;
    }
}
