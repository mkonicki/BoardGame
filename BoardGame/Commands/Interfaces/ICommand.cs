using BoardGame.EventStores.Interfaces;

namespace BoardGame.Commands.Interfaces
{
    public interface ICommand<TEvent>
        where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }

    public interface ICommand<TEvent, TResponse>
        where TEvent : IEvent
        where TResponse : new()
    {
        TResponse Handle(TEvent @event);
    }
}
