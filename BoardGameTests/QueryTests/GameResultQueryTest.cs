using BoardGame.Calculators;
using BoardGame.Commands;
using BoardGame.Data.Enums;
using BoardGame.EventStores;
using BoardGame.EventStores.Interfaces;
using BoardGame.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BoardGameTests.QueryTests
{
    [TestClass]
    public class GameResultQueryTest
    {
        private IEventStore store;
        private GameCommand gameCommand;
        private MoveCommand moveCommand;
        private GameResultQuery gameResultQuery;

        [TestInitialize]
        public void Initalize()
        {
            store = new EventStore();
            gameCommand = new GameCommand(store);
            moveCommand = new MoveCommand(store);
            gameResultQuery = new GameResultQuery(store, new GameResultCalculator());
        }

        [TestMethod]
        public void CalculateFinalResult_Expected_22E()
        {
            //ARRANGE
            var gameEvent = new GameEvent();

            var moves = new List<MoveEvent>
            {
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Left),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId)
            };

            //ACT
            gameCommand.Handle(gameEvent);

            moves.ForEach(moveCommand.Handle);

            var gameResult = gameResultQuery.Handle(new GameResultEvent { GameId = gameEvent.GameId });

            //ASSERT
            Assert.AreEqual(Direction.East, gameResult.Direction);
            Assert.AreEqual(2, gameResult.X);
            Assert.AreEqual(2, gameResult.Y);
        }

        [TestMethod]
        public void CalculateFinalResult_Expected_32N()
        {
            //ARRANGE
            var gameEvent = new GameEvent();

            var moves = new List<MoveEvent>
            {
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId),
                new MoveEvent(gameEvent.GameId),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Left),
                new MoveEvent(gameEvent.GameId),
                new MoveEvent(gameEvent.GameId)
            };

            //ACT
            gameCommand.Handle(gameEvent);

            moves.ForEach(moveCommand.Handle);

            var gameResult = gameResultQuery.Handle(new GameResultEvent { GameId = gameEvent.GameId });

            //ASSERT 
            Assert.AreEqual(Direction.North, gameResult.Direction);
            Assert.AreEqual(3, gameResult.X);
            Assert.AreEqual(2, gameResult.Y);
        }

        [TestMethod]
        public void CalculateFinalResult_Expected_04N()
        {
            //ARRANGE
            var gameEvent = new GameEvent();

            var moves = new List<MoveEvent>
            {
                new MoveEvent(gameEvent.GameId),
                new MoveEvent(gameEvent.GameId),
                new MoveEvent(gameEvent.GameId),
                new MoveEvent(gameEvent.GameId),
                new MoveEvent(gameEvent.GameId)
            };

            //ACT
            gameCommand.Handle(gameEvent);

            moves.ForEach(moveCommand.Handle);

            var gameResult = gameResultQuery.Handle(new GameResultEvent { GameId = gameEvent.GameId });

            //ASSERT
            Assert.AreEqual(Direction.North, gameResult.Direction);
            Assert.AreEqual(0, gameResult.X);
            Assert.AreEqual(4, gameResult.Y);
        }

        [TestMethod]
        public void CalculateFinalResult_Expected_00N()
        {
            //ARRANGE
            var gameEvent = new GameEvent();

            var moves = new List<MoveEvent>
            {
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
            };

            //ACT
            gameCommand.Handle(gameEvent);

            moves.ForEach(moveCommand.Handle);

            var gameResult = gameResultQuery.Handle(new GameResultEvent { GameId = gameEvent.GameId });

            //ASSERT      

            Assert.AreEqual(Direction.North, gameResult.Direction);
            Assert.AreEqual(0, gameResult.X);
            Assert.AreEqual(0, gameResult.Y);
        }

        [TestMethod]
        public void CalculateFinalResult_Expected_44N()
        {
            //ARRANGE
            var gameEvent = new GameEvent();

            var moves = new List<MoveEvent>
            {
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Left),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Left),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Left),
                new MoveEvent(gameEvent.GameId),
                new RotateEvent(gameEvent.GameId, RotateDirection.Right),
                new MoveEvent(gameEvent.GameId),
            };

            //ACT
            gameCommand.Handle(gameEvent);

            moves.ForEach(moveCommand.Handle);

            var gameResult = gameResultQuery.Handle(new GameResultEvent { GameId = gameEvent.GameId });

            //ASSERT 
            Assert.AreEqual(Direction.East, gameResult.Direction);
            Assert.AreEqual(4, gameResult.X);
            Assert.AreEqual(4, gameResult.Y);
        }
    }
}
