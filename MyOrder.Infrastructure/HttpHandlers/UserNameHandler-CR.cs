//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;

//namespace MyOrder.Infrastructure.HttpHandlers;

//public class UserNameHandler(IHttpContextAccessor httpContextAccessor, ILogger<UserNameHandler> logger) : DelegatingHandler
//{
//    private const string HEADER_PARAM_AUTHENTICATED_USER = "X-Authenticated-User";

//    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//    {
//#if DEBUG
//        //logger.LogWarning("Hardcoded http header {Param} value for testing purposes", HEADER_PARAM_AUTHENTICATED_USER);

//        request.Headers.Add(HEADER_PARAM_AUTHENTICATED_USER, "RAJA-GROUP\\CRevillon");

//        return await base.SendAsync(request, cancellationToken);
//#else
//        try
//        {
//            if (httpContextAccessor.HttpContext != null)
//            {
//                var user = httpContextAccessor.HttpContext.User;

//                // Check if the user is authenticated and the Identity is not null
//                if (user?.Identity?.IsAuthenticated == true)
//                {
//                    var userName = user.Identity.Name;

//                    if (!string.IsNullOrEmpty(userName))
//                    {
//                        if (!request.Headers.Contains(HEADER_PARAM_AUTHENTICATED_USER))
//                        {
//                            request.Headers.Add(HEADER_PARAM_AUTHENTICATED_USER, userName);
//                            logger.LogInformation("Added {UserIdentityName} header with value {UserName}",
//                                HEADER_PARAM_AUTHENTICATED_USER, userName);
//                        }
//                    }
//                    else
//                    {
//                        logger.LogWarning("Authenticated user has no name.");
//                    }
//                }
//                else
//                {
//                    logger.LogWarning("User is not authenticated.");
//                }
//            }
//            else
//            {
//                logger.LogError("HttpContext is null.");
//            }
//        }
//        catch (Exception ex)
//        {
//            logger.LogError(ex, "An error occurred while adding the X-Authenticated-User header.");
//            throw;
//        }

//        return await base.SendAsync(request, cancellationToken);
//#endif

//    }
//}