using System.Collections.Generic;

namespace BoardGame.EventStores.Interfaces
{
    public interface IEventStore
    {
        void StoreEvent(IEvent @event);

        ICollection<T> GetEvents<T>() where T : IEvent;
    }
}
