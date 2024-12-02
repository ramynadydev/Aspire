using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspireApp1.ServiceDefaults.Model;
using AspireApp1.ServiceDefaults.Publisher;

namespace AspireApp1.ServiceDefaults.Service
{
    public class OrderService
    {
        private readonly FileStorageService _fileStorage;
        private readonly EventPublisher _eventPublisher;

        public OrderService(FileStorageService fileStorage, EventPublisher eventPublisher)
        {
            _fileStorage = fileStorage;
            _eventPublisher = eventPublisher;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            var orders = await _fileStorage.LoadAsync<Order>("orders.json");
            order.Id = orders.Any() ? orders.Max(o => o.Id) + 1 : 1;
            orders.Add(order);

            await _fileStorage.SaveAsync("orders.json", orders);

            var orderCreatedEvent = new OrderCreatedEvent
            {
                OrderId = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                CreatedAt = order.CreatedAt
            };

            _eventPublisher.Publish(orderCreatedEvent);

            return order;
        }
    }

}
