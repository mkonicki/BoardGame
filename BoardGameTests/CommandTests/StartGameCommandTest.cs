﻿using BoardGame.Commands;
using BoardGame.EventStores;
using BoardGame.EventStores.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BoardGameTests.CommandTests
{
    [TestClass]
    public class StartGameCommandTest
    {
        private IEventStore store;

        [TestInitialize]
        public void Initalize() => store = new EventStore();

        [TestMethod]
        public void StartGame()
        {
            //ARRANGE
            var @event = new StartGameEvent();
            var command = new StartGameCommand(store);

            //ACT
            command.Handle(@event);

            //ASSERT
            var storedEvents = store.GetEvents<StartGameEvent>();

            Assert.AreEqual(true, storedEvents.Contains(@event));
            Assert.AreEqual(1, storedEvents.Count);
        }

        [TestMethod]
        public void EachGameHasDiffrentId()
        {
            //ARRANGE
            var firstGame = new StartGameEvent();
            var secondGame = new StartGameEvent();
            var command = new StartGameCommand(store);

            //ACT
            command.Handle(firstGame);
            command.Handle(secondGame);

            //ASSERT
            var storedEvents = store.GetEvents<StartGameEvent>();

            Assert.AreEqual(true, storedEvents.Contains(firstGame));
            Assert.AreEqual(true, storedEvents.Contains(secondGame));
            Assert.AreEqual(firstGame, storedEvents.Single(e => e.GameId == firstGame.GameId));
            Assert.AreEqual(secondGame, storedEvents.Single(e => e.GameId == secondGame.GameId));
        }
    }
}