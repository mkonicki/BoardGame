using BoardGame.Commands.Interfaces;
using BoardGame.EventStores;
using BoardGame.EventStores.Interfaces;
using System;

namespace BoardGame.Commands
{
    public class MoveCommand : ICommand<MoveEvent>
    {
        private readonly IEventStore _eventStore;

        public MoveCommand(IEventStore eventStore) => _eventStore = eventStore;

        public MoveCommand() : this(EventStore.Instance)
        {
        }

        public void Handle(MoveEvent @event) => _eventStore.StoreEvent(@event);
    }

    public class MoveEvent : IEvent
    {
        public Guid GameId { get; set; }

        public MoveEvent(Guid gameId)
        {
            GameId = gameId;
        }
    }

    public class RotateEvent : MoveEvent
    {
        public RotateDirection RotateDirection;

        public RotateEvent(Guid gameId, RotateDirection rotateDirection) : base(gameId)
        {
            RotateDirection = rotateDirection;
        }
    }


}
