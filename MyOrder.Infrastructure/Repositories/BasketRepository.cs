using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketApiClient apiClient;
        private readonly ILogger<BasketRepository> logger;

        public BasketRepository(IBasketApiClient apiClient, ILogger<BasketRepository> logger)
        {
            this.apiClient = apiClient;
            this.logger = logger;
        }

        public async Task<BasketHeaderDto> GetBasketHeaderAsync(string basketId)
        {
            logger.LogInformation("Fetching basket header for {BasketId} from repository", basketId);
            return await apiClient.GetBasketHeaderAsync(basketId);
        }

        /*
        public async Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId)
        {
            _logger.LogInformation("Fetching notifications for {BasketId} from repository", basketId);
            return await _apiClient.GetNotificationsAsync(basketId);
        }

        public async Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId)
        {
            _logger.LogInformation("Fetching basket lines for {BasketId} from repository", basketId);
            return await _apiClient.GetBasketLinesAsync(basketId);
        }
        */
    }
}
