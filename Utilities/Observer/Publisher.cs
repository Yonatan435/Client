using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Observer
{
    public class Publisher : IPublisher
    {
        Dictionary<Type, List<Action<Event>>> _eventToAction;
        
        public Publisher()
        {
            _eventToAction = new Dictionary<Type, List<Action<Event>>>();
        }
        public IDisposable Register<T>(Action<T> handler) where T : Event
        {
            var type = typeof(T);
            if (!_eventToAction.ContainsKey(type))
                _eventToAction.Add(type, new List<Action<Event>>());
            Action<Event> action = Convert<T>(handler);
            _eventToAction[type].Add(action);
            Action unregisterAction = () => { _eventToAction[type].Remove(action); };
            return new Disposer(unregisterAction);
            
        }

        protected Action<Event> Convert<T>(Action<T> handler) where T : Event
        {
            return (Event e) =>
            {
                handler((T)e);
            };
        }
        public void Publish(Event @event)
        {
            foreach (var handler in _eventToAction[@event.GetType()])
            {
                handler.Invoke(@event);
            }
        }

    }
}
