using Microsoft.Extensions.Logging;
using MyOrder.Shared.Dtos;
using Newtonsoft.Json;
using Refit;
using System.Net;

namespace MyOrder.Infrastructure.Utils;

public static class ApiErrorHelper
{
    public static async Task<string> GetApiError(ApiException apiException, ILogger logger)
    {
        var errorMessage = string.Empty;
        try
        {
            var errorWrapper = await apiException.GetContentAsAsync<ApiErrorResponseDto>();
            var response = errorWrapper?.Error;
            if (response is not null && !string.IsNullOrWhiteSpace(response.Message))
            {
                var prettyJson = JsonConvert.SerializeObject(response, Formatting.Indented);

                var normalizedPrettyJson = UnescapeErrorMessage(prettyJson);

                var formattedContent = $"<pre>{WebUtility.HtmlEncode(normalizedPrettyJson)}</pre>";

                errorMessage = $"{response.Code}: \n{formattedContent}";
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to parse API error response.");
        }
        finally
        {
            if (string.IsNullOrEmpty(errorMessage))
                errorMessage = $"Server returned {apiException.StatusCode} : {apiException.Message}";
        }
        return errorMessage;
    }

    private static string UnescapeErrorMessage(string message) =>
        message.Replace("\\r\\n", "\n")
               .Replace("\\n", "\n")
               .Replace("\\r", "\n")
               .Replace("\\\"", "\"");
}