using BoardGame.EventStores.Interfaces;

namespace BoardGame.Queries.Interfaces
{
    public interface IQuery<TEvent, TResponse>
        where TEvent : IEvent
    {
        TResponse Handle(TEvent @event);
    }
}
