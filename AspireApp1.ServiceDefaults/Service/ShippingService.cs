using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspireApp1.ServiceDefaults.Model;

namespace AspireApp1.ServiceDefaults.Service
{
    public class ShippingService
    {
        public void OnOrderCreated(OrderCreatedEvent orderEvent)
        {
            Console.WriteLine($"Shipping Service: Processing Order {orderEvent.OrderId} for Product {orderEvent.ProductId}");
            // Simulate shipping logic here
        }
    }

}
