﻿using System;
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
        public HeroController(tunbasedbattlerContext dbContext)
        {
            this.heroService = new HeroService(dbContext);
            heroView = new HeroView();
        }

        public void CreateHero(string name, string type, int id)
        {
            heroService.CreateHero(name, type, id);
        }

        public void HeroStatus(string name, int playerId)
        {
            heroView.HeroStatus(heroService.GetHeroStatus(name, playerId));
        }

        public void DeleteHero(HeroViewModel deadHero)
        {
            heroService.DeleteHero(deadHero);
        }
    }
}