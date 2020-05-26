using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Models;
using TurnBasedBattler.Models.DTOs;
using TurnBasedBattler.Services;
using TurnBasedBattler.Views;

namespace TurnBasedBattler.Controllers
{
    class HeroController
    {
        private readonly HeroService heroService;
        private HeroView heroView;
        public HeroController(tunbasedbattlerContext dbContext, PlayerViewModel player)
        {
            this.heroService = new HeroService(dbContext);
            heroView = new HeroView();
        }

        public void CreateHero(HeroViewModel newHero)
        {
            heroService.CreateHero(newHero);
        }

        public void HeroStatus(HeroViewModel heroToFind, int playerId)
        {
            heroView.HeroStatus(heroService.GetHeroStatus(heroToFind, playerId));
        }

        public void DeleteHero(HeroViewModel deadHero)
        {
            heroService.DeleteHero(deadHero);
        }
    }
}