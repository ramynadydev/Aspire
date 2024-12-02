using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp1.ServiceDefaults.Publisher
{
    public interface IEventHandler<T> where T : class
    {
        void Handle(T @event);
    }

}
