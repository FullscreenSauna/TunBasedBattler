using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Models;
using TurnBasedBattler.Models.DTOs;
using TurnBasedBattler.Services;

namespace TurnBasedBattler.Controllers
{
    public class HeroController
    {
        private readonly HeroService heroService;
        public HeroController(tunbasedbattlerContext dbContext)
        {
            this.heroService = new HeroService(dbContext);
        }

        public void CreateHero(HeroViewModel newHero)
        {
            heroService.CreateHero(newHero);
        }

        public string HeroStatus(HeroViewModel heroToFind)
        {
            return heroService.GetHeroStatus(heroToFind);
        }

        public void DeleteHero(HeroViewModel deadHero)
        {
            heroService.DeleteHero(deadHero);
        }
    }
}