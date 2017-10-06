using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Observer
{
    public interface IPublisher
    {
        IDisposable Register<T>(Action<T> handler) where T : Event;
        void Publish(Event @event);
    }
}
