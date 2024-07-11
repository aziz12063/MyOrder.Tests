using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Infrastructure.ApiClients
{
    public class BasketApiClient : IBasketApiClient
    {
        private readonly IBasketApiClient apiClient;
        private readonly ILogger<BasketApiClient> logger;

        public BasketApiClient(IBasketApiClient apiClient, ILogger<BasketApiClient> logger)
        {
            this.apiClient = apiClient;
            this.logger = logger;
        }

        public async Task<BasketHeaderDto> GetBasketHeaderAsync(string basketId)
        {
            logger.LogInformation("Fetching basket header for {BasketId}", basketId);

            try
            {
                return await apiClient.GetBasketHeaderAsync(basketId);
            }
            catch (ApiException ex)
            {
                logger.LogError(ex, "Error fetching basket header for {BasketId}", basketId);
                throw;
            }
        }

        /*
        public async Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId)
        {
            logger.LogInformation("Fetching notifications for {BasketId}", basketId);
            try
            {
                return await apiClient.GetNotificationsAsync(basketId);
            }
            catch (ApiException ex)
            {
                logger.LogError(ex, "Error fetching notifications for {BasketId}", basketId);
                throw;
            }
        }

        public async Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId)
        {
            logger.LogInformation("Fetching basket lines for {BasketId}", basketId);
            try
            {
                return await apiClient.GetBasketLinesAsync(basketId);
            }
            catch (ApiException ex)
            {
                logger.LogError(ex, "Error fetching basket lines for {BasketId}", basketId);
                throw;
            }
        }
        */
    }
}
