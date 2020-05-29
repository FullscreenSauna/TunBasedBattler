using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedBattler.Models;
using TurnBasedBattler.Services;

namespace TurnBasedBattlerTests
{
    class HeroTests
    {
        private tunbasedbattlerContext dbContext;
        private HeroService testHeroService;

        [SetUp]
        public void SetUp()
        {
            dbContext = new tunbasedbattlerContext();
            testHeroService = new HeroService(dbContext);
        }

        [Test]
        public void CreateHeroTest_Successful()
        {
            string newHeroName = "testHero";
            string newHeroType = "Wizzard";
            int newHeroPlayerId = 1;

            testHeroService.CreateHero(newHeroName, newHeroType, newHeroPlayerId);

            Assert.IsNotNull(dbContext.Heroes.FirstOrDefault(h => h.Name == newHeroName));
        }

        [Test]
        public void CreateHeroWithWrongTypeTest_ThrowsException()
        {
            string newHeroName = "testHero2";
            string newHeroType = "wrong type";
            int newHeroPlayerId = 1;
            try
            {
                testHeroService.CreateHero(newHeroName, newHeroType, newHeroPlayerId);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The type was not correct", ex.Message);
            }
        }

        [Test]
        public void CreateExisentHeroTest_ThrowsException()
        {
            string newHeroName = "testHero";
            string newHeroType = "Wizzard";
            int newHeroPlayerId = 1;
            try
            {
                testHeroService.CreateHero(newHeroName, newHeroType, newHeroPlayerId);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Hero with name {newHeroName} already exists", ex.Message);
            }
        }

        [Test]
        public void GetHeroStatusTest_Successful()
        {
            string heroName = "testHero";
            int heroPlayerId = 1;

            string expectedStatus = $"{heroName}- HP:75 ATK:1/DEF:-2/MAG:8/DodgeChance:2%";
            string actualStatus = testHeroService.GetHeroStatus(heroName, heroPlayerId);
            Assert.AreEqual(expectedStatus, actualStatus);
        }


        [Test]
        public void GetDeletedHeroStatusTest_ThrowsException()
        {
            string heroName = "non-existent hero";
            int heroPlayerId = 1;

            string expectedStatus = "Hero does not exist or is dead";
            string actualStatus = testHeroService.GetHeroStatus(heroName, heroPlayerId);

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void DeleteHeroTest_Successful()
        {
            string deadHeroName = "testHero";
            testHeroService.DeleteHero(deadHeroName);
            Assert.IsNull(dbContext.Heroes.FirstOrDefault(h => h.Name == deadHeroName));
        }

        [Test]
        public void DeleteHeroTest_ThrowsException()
        {
            string deadHeroName = "non-existent hero";
            try
            {
                testHeroService.DeleteHero(deadHeroName);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Hero with name {deadHeroName} doesn't exist", ex.Message);
            }
        }


    }
}
