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
        public void StoreMovesEventTest()
        {
            //ARRANGE
            var @event = new MoveEvent(new Guid());

            var command = new MoveCommand(store);

            //ACT
            command.Handle(@event);

            //ASSERT
            var storedEvents = store.GetEvents<MoveEvent>();

            Assert.AreEqual(true, storedEvents.Contains(@event));
            Assert.AreEqual(1, storedEvents.Count);
        }

        [TestMethod]
        public void StoreTurnsEventTest()
        {
            //ARRANGE
            var @event = new RotateEvent(new Guid(), RotateDirection.Left);

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
