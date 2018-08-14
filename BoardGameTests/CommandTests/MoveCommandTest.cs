using BoardGame;
using BoardGame.Commands;
using BoardGame.EventStores;
using BoardGame.EventStores.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BoardGameTests.CommandTests
{
    [TestClass]
    public class MoveCommandTest
    {
        private IEventStore store;

        [TestInitialize]
        public void Initalize() => store = new EventStore();

        [TestMethod]
        public void StoreMovesTest()
        {
            //ARRANGE
            var @event = new MoveEvent
            {
                GameId = new Guid(),
                Direction = Direction.East
            };
            var command = new MoveCommand(store);

            //ACT
            command.Handle(@event);

            //ASSERT
            var storedEvents = store.GetEvents<MoveEvent>();

            Assert.AreEqual(true, storedEvents.Contains(@event));
            Assert.AreEqual(1, storedEvents.Count);
        }
    }
}
