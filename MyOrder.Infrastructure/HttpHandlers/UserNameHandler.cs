using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MyOrder.Infrastructure.HttpHandlers;

public class UserNameHandler(IHttpContextAccessor httpContextAccessor, ILogger<UserNameHandler> logger) : DelegatingHandler
{
    private const string USER_IDENTITY_NAME_HEADER = "User-Identity-Name";
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            if (httpContextAccessor.HttpContext != null)
            {
                var user = httpContextAccessor.HttpContext.User;

                // Check if the user is authenticated and the Identity is not null
                if (user?.Identity?.IsAuthenticated == true)
                {
                    var userName = user.Identity.Name;

                    if (!string.IsNullOrEmpty(userName))
                    {
                        if (!request.Headers.Contains(USER_IDENTITY_NAME_HEADER))
                        {
                            request.Headers.Add(USER_IDENTITY_NAME_HEADER, userName);
                            logger.LogInformation("Added {UserIdentityName} header with value {UserName}",
                                USER_IDENTITY_NAME_HEADER, userName);
                        }
                    }
                    else
                    {
                        logger.LogWarning("Authenticated user has no name.");
                    }
                }
                else
                {
                    logger.LogWarning("User is not authenticated.");
                }
            }
            else
            {
                logger.LogError("HttpContext is null.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while adding the X-Authenticated-User header.");
            throw;
        }

        return await base.SendAsync(request, cancellationToken);
    }

}