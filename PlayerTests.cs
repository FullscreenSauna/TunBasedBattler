using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedBattler.Models;
using TurnBasedBattler.Models.DTOs;
using TurnBasedBattler.Services;

namespace TurnBasedBattlerTests
{
    class PlayerTests
    {
        private tunbasedbattlerContext dbContext;
        private PlayerService testPlayerService;

        private int newPlayerId;

        private void GetPlayerId(string name)
        {
            PlayerViewModel myPlayer = testPlayerService.GetPlayerByName(name);
            newPlayerId = myPlayer.Id;
        }

        [SetUp]
        public void SetUp()
        {
            dbContext = new tunbasedbattlerContext();
            testPlayerService = new PlayerService(dbContext);
        }

        [Test]
        public void CreatePlayerTest_Successful()
        {
            //You need no change newPlayerName every time
            string newPlayerName = "1111";

            testPlayerService.CreatePlayer(newPlayerName);

            Assert.IsTrue(testPlayerService.Exists(newPlayerName));
            GetPlayerId(newPlayerName);
        }

        [Test]
        public void CreatePlayerTest_ThrowsException()
        {
            string newPlayerName = "1111";
            try
            {
                testPlayerService.CreatePlayer(newPlayerName);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Player with name {newPlayerName} already exists", ex.Message);
            }

        }

        [Test]
        public void DeletePlayerTest_Successful()
        {
            //Problem: You need to chahge playerId every time
            //int playerId = 41;
            int playerId = newPlayerId;
            string confirmation = "yes";
            testPlayerService.DeletePlayer(playerId, confirmation);
            Assert.IsFalse(testPlayerService.Exists(playerId));
        }

        [Test]
        public void DeletePlayerTest_ThrowsException()
        {
            try
            {
                int plaierId = 40;
                string confirmation = "no";
                testPlayerService.DeletePlayer(plaierId, confirmation);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Failed to confirm the deletion process", ex.Message);
            }
        }

        [Test]
        public void GetPlayerByNameTest_Successful()
        {
            string name = "FirstPlayer";

            var expectedPlayer = this.dbContext
                             .Players
                             .Where(pl => pl.Username == name)
                             .Include(h => h.Heroes)
                             .FirstOrDefault();

            var actualPlayer = testPlayerService.GetPlayerByName(name);
            Assert.AreEqual(expectedPlayer.Id, actualPlayer.Id);
            Assert.AreEqual(expectedPlayer.Username, actualPlayer.Username);
            Assert.AreEqual(expectedPlayer.Heroes.Count, actualPlayer.Heroes.Count);

        }

        [Test]
        public void GetPlayerByNameTest_ThrowsException()
        {
            string name = "FirstPlayer";
            try
            {
                testPlayerService.GetPlayerByName(name);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Player {name} does not exist", ex.Message);
            }
        }

        [Test]
        public void GetPlayerByIdTest_Successful()
        {
            int id = 1;

            var expectedPlayer = this.dbContext
                             .Players
                             .Where(pl => pl.Id == id)
                             .Include(h => h.Heroes)
                             .FirstOrDefault();

            var actualPlayer = testPlayerService.GetPlayerById(id);
            Assert.AreEqual(expectedPlayer.Id, actualPlayer.Id);
            Assert.AreEqual(expectedPlayer.Username, actualPlayer.Username);
            Assert.AreEqual(expectedPlayer.Heroes.Count, actualPlayer.Heroes.Count);
        }

        [Test]
        public void GetAllPlayerNamesTest_Successful()
        {
            List<string> expected = dbContext.Players.Select(p => p.Username).ToList();
            List<string> actual = testPlayerService.GetAllPlayerNames();
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[expected.Count / 2], actual[expected.Count / 2]);
            Assert.AreEqual(expected[expected.Count - 1], actual[expected.Count - 1]);
        }

    }
}
