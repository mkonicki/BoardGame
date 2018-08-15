using BoardGame.Calculators;
using BoardGame.Commands;
using BoardGame.EventStores;
using BoardGame.EventStores.Interfaces;
using BoardGame.Queries.Interfaces;
using System;
using System.Linq;

namespace BoardGame.Queries
{
    public class GameResultQuery : IQuery<GameResultEvent, GameResult>
    {
        private readonly IEventStore _eventStore;
        private readonly IGameResultCalculator _gameResultCalculator;

        public GameResultQuery(IEventStore eventStore, IGameResultCalculator gameResultCalculator)
        {
            _eventStore = eventStore;
            _gameResultCalculator = gameResultCalculator;
        }

        public GameResultQuery() : this(EventStore.Instance, new GameResultCalculator())
        {
        }

        public GameResult Handle(GameResultEvent @event)
        {
            var game = _eventStore.GetEvents<GameEvent>()
                .SingleOrDefault(e => e.GameId == @event.GameId);

            if (game == null)
            {
                return null;
            }

            var moves = _eventStore.GetEvents<MoveEvent>()
                .Where(e => e.GameId == @event.GameId)
                .ToList();

            return _gameResultCalculator.CalculateGameResult(game, moves);
        }
    }

    public class GameResultEvent : IEvent
    {
        public Guid GameId { get; set; }
    }
}
