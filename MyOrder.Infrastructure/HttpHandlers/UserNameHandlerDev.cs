using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyOrder.Shared.Utils;

namespace MyOrder.Infrastructure.HttpHandlers;

public class UserNameHandlerDev(IHttpContextAccessor httpContextAccessor, ILogger<UserNameHandler> logger) : DelegatingHandler
{
    private const string HEADER_PARAM_AUTHENTICATED_USER = "X-Authenticated-User";
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Hardcoded http header {Param} value for testing purposes", HEADER_PARAM_AUTHENTICATED_USER);

        request.Headers.Add(HEADER_PARAM_AUTHENTICATED_USER, "RAJA-GROUP\\imad.BOUGATAIA.ext");
        
        return await base.SendAsync(request, cancellationToken);
    }

}