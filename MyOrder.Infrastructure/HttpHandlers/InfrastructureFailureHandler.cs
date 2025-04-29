using Microsoft.Extensions.Logging;
using MyOrder.Shared.Events;
using MyOrder.Shared.Interfaces;
using Polly.Timeout;
using System.Net;
using System.Net.Sockets;

namespace MyOrder.Infrastructure.HttpHandlers;

public class InfrastructureFailureHandler(IEventAggregator eventAggregator, ILogger<InfrastructureFailureHandler> logger) : DelegatingHandler
{
    private readonly IEventAggregator _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
    private readonly ILogger<InfrastructureFailureHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
   
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            return await base.SendAsync(request, cancellationToken);
        }
        catch (TimeoutRejectedException trex)
        {
            // Handle timeout exceptions (from pessimistic strategy)
            var timeoutEvent = new ApiTimeoutEvent(
                message: "The request is taking longer than expected. Please try again later.",
                exception: trex
            );

            await _eventAggregator.PublishAsync(timeoutEvent);
            _logger.LogError(trex, "API request to {RequestUri} timed out.", request.RequestUri);

            return new HttpResponseMessage(HttpStatusCode.RequestTimeout)
            {
                Content = new StringContent("The request timed out. Please try again later.")
            };
        }
        catch (HttpRequestException httpEx) when (httpEx.InnerException is SocketException)
        {
            // Handle server unreachable scenarios
            var serverUnreachableEvent = new BackendServiceUnavailableEvent(
                message: "We're unable to connect to the service at the moment. Please try again later.",
                exception: httpEx
            );

            await _eventAggregator.PublishAsync(serverUnreachableEvent);
            _logger.LogError(httpEx, "Server is unreachable.");

            return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
            {
                Content = new StringContent("Service is currently unavailable. Please try again later.")
            };
        }
        catch (Exception ex)
        {
            // Handle any other unexpected exceptions
            var generalErrorEvent = new InfrastructureFailureEvent(
                message: "An unexpected error occurred.",
                exception: ex
            );

            await _eventAggregator.PublishAsync(generalErrorEvent);
            _logger.LogError(ex, "An unexpected infrastructure error occurred.");

            throw;
        }
    }
}