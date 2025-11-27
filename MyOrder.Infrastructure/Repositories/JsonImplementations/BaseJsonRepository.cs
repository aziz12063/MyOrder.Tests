using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.Utils;
using MyOrder.Shared.Events;
using MyOrder.Shared.Interfaces;
using Refit;
using System.Net;

namespace MyOrder.Infrastructure.Repositories.JsonImplementations;

public abstract class BaseJsonRepository
{
    protected readonly IEventAggregator _eventAggregator;
    protected readonly ILogger<BaseJsonRepository> _logger;
    protected readonly IBasketService _basketService;
    protected readonly IWebHostEnvironment _environment;
    protected readonly string baseDataPath;

    protected BaseJsonRepository(
        IEventAggregator eventAggregator,
        IBasketService basketService,
        ILogger<BaseJsonRepository> logger,
        IWebHostEnvironment environment)
    {
        _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        baseDataPath = Path.Combine(_environment.WebRootPath, "..", "..", "..", "MyOrder.Tests","Infrastructure", "Data");
    }


    protected string BasketId
    {
        get
        {
            var basketId = _basketService.BasketId;
            if (string.IsNullOrEmpty(basketId))
            {
                throw new NullReferenceException(nameof(basketId));
            }
            return basketId;
        }
    }
    protected string CompanyId
    {
        get
        {
            var myOrderController = _basketService.CompanyId;
            if (string.IsNullOrEmpty(myOrderController))
            {
                throw new NullReferenceException(nameof(myOrderController));
            }
            return myOrderController;
        }
    }

    /// <summary>
    /// Executes an API call within a standardized try-catch block.
    /// </summary>
    /// <typeparam name="T">The type of the API response.</typeparam>
    /// <param name="apiCall">A function representing the API call.</param>
    /// <param name="operationDescription">A description of the operation for logging purposes.</param>
    /// <param name="cancellationToken">Token to observe while waiting for the task to complete.</param>
    /// <returns>The result of the API call, or null if an exception occurs.</returns>
    protected async Task<T?> ExecuteAsync<T>(Func<CancellationToken, Task<T?>> apiCall, string operationDescription, CancellationToken cancellationToken) where T : class
    {
        try
        {
            _logger.LogInformation("Executing operation: {OperationDescription}", operationDescription);
            return await apiCall(cancellationToken);
        }
        catch (ApiException apiEx)
        {
            await HandleApiException(apiEx, operationDescription);
            return null; // Return null to signify failure
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected exception during {OperationDescription}", operationDescription);
            return null;
        }
    }

    /// <summary>
    /// Handles ApiException by publishing appropriate events based on the HTTP status code.
    /// </summary>
    private async Task HandleApiException(ApiException apiEx, string operationDescription)
    {
        var errorMessage = await ApiErrorHelper.GetApiError(apiEx, _logger);
        _logger.LogError(apiEx,
            "API Exception during {OperationDescription}\n" +
            "Server returned : \n" +
            "{ApiErrorResponse}",
            operationDescription,
            errorMessage);

        _eventAggregator.PublishAsync(new ApiErrorEvent(errorMessage, (int)apiEx.StatusCode, apiEx));

        //switch (apiEx.StatusCode)
        //{
        //    case HttpStatusCode.BadRequest:
        //        _eventAggregator.Publish(new ApiErrorEvent("Bad request.", (int)apiEx.StatusCode, apiEx));
        //        break;
        //    case HttpStatusCode.Unauthorized:
        //    case HttpStatusCode.Forbidden:
        //        _eventAggregator.Publish(new ApiErrorEvent("Authentication or authorization error.", (int)apiEx.StatusCode, apiEx));
        //        break;
        //    case HttpStatusCode.NotFound:
        //        _eventAggregator.Publish(new ApiErrorEvent("Resource not found.", (int)apiEx.StatusCode, apiEx));
        //        break;
        //    case HttpStatusCode.RequestTimeout:
        //        _eventAggregator.Publish(new ApiTimeoutEvent("The request timed out. Please try again later.", apiEx));
        //        break;
        //    case HttpStatusCode.ServiceUnavailable:
        //    case HttpStatusCode.GatewayTimeout:
        //        _eventAggregator.Publish(new BackendServiceUnavailableEvent("Service is currently unavailable. Please try again later.", apiEx));
        //        break;
        //    default:
        //        _eventAggregator.Publish(new ApiErrorEvent($"API Error: {(int)apiEx.StatusCode}", (int)apiEx.StatusCode, apiEx));
        //        break;
        //}
    }
}
