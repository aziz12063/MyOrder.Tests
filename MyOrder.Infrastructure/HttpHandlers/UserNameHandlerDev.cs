using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyOrder.Shared.Utils;

namespace MyOrder.Infrastructure.HttpHandlers;

public class UserNameHandlerDev(IWebHostEnvironment environment,
    ILogger<UserNameHandler> logger) : DelegatingHandler
{
    private const string HEADER_PARAM_AUTHENTICATED_USER = "X-Authenticated-User";
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!environment.IsDevelopment())
            logger.LogWarning("Hardcoded http header {Param} value for testing purposes", HEADER_PARAM_AUTHENTICATED_USER);

        request.Headers.Add(HEADER_PARAM_AUTHENTICATED_USER, "RAJA-GROUP\\imad.BOUGATAIA.ext");

        return await base.SendAsync(request, cancellationToken);
    }

}