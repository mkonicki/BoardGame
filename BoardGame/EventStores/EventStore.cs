using BoardGame.EventStores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGame.EventStores
{
    public class EventStore : IEventStore
    {
        public static IEventStore Instance => initializer.Value;

        private static readonly Lazy<IEventStore> initializer
            = new Lazy<IEventStore>(() => new EventStore());

        private readonly ICollection<IEvent> Events;

        public EventStore()
        {
            Events = new List<IEvent>();
        }

        public ICollection<T> GetEvents<T>() where T : IEvent
        {
            return Events.Where(e => e.GetType() == typeof(T))
                .Select(e => (T)e)
                .ToList();
        }

        public void StoreEvent(IEvent @event)
        {
            Events.Add(@event);
        }
    }
}
