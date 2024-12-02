using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AspireApp1.ServiceDefaults.Publisher
{
    public class EventPublisher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Publish<T>(T @event) where T : class
        {
            // Resolve all event handlers for the given event type
            var handlers = _serviceProvider.GetServices<IEventHandler<T>>();

            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }

}
