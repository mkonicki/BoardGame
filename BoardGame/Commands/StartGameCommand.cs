using BoardGame.Commands.Interfaces;
using BoardGame.EventStores;
using BoardGame.EventStores.Interfaces;
using System;

namespace BoardGame.Commands
{
    public class StartGameCommand : ICommand<StartGameEvent, Guid>
    {
        private readonly IEventStore _eventStore;

        public StartGameCommand(IEventStore eventStore) => _eventStore = eventStore;

        public StartGameCommand() : this(EventStore.Instance)
        {
        }

        public Guid Handle(StartGameEvent @event)
        {
            _eventStore.StoreEvent(@event);

            return @event.GameId;
        }
    }

    public class StartGameEvent : IEvent
    {
        public Guid GameId;

        public StartGameEvent() => GameId = Guid.NewGuid();
    }
}
