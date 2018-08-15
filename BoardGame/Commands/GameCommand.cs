using BoardGame.Commands.Interfaces;
using BoardGame.EventStores;
using BoardGame.EventStores.Interfaces;
using System;

namespace BoardGame.Commands
{
    public class GameCommand : ICommand<GameEvent, Guid>
    {
        private readonly IEventStore _eventStore;

        public GameCommand(IEventStore eventStore) => _eventStore = eventStore;

        public GameCommand() : this(EventStore.Instance)
        {
        }

        public Guid Handle(GameEvent @event)
        {
            _eventStore.StoreEvent(@event);

            return @event.GameId;
        }
    }

    public class GameEvent : IEvent
    {
        public Guid GameId;

        public Board Board;

        public GameEvent()
        {
            GameId = Guid.NewGuid();
            Board = new Board();
        }
    }
}
