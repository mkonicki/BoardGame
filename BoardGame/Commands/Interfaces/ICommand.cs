using BoardGame.EventStores;

namespace BoardGame.Commands.Interfaces
{
    public interface ICommand<TEvent>
        where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }

    public interface ICommand<TEvent, TResponse>
        where TEvent : IEvent
    {
        TResponse Handle(TEvent @event);
    }
}
