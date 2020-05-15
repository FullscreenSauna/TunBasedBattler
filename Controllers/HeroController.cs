using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Models.DTOs;
using TurnBasedBattler.Services;

namespace TurnBasedBattler.Controllers
{
    public class HeroController
    {
        private readonly HeroService heroService;
        private readonly HeroViewModel heroViewModel;

        //TODO add servise
        public HeroController(HeroService heroService, HeroViewModel heroViewModel)
        {
            this.heroService = heroService;
            this.heroViewModel = heroViewModel;
        }

        public void Create(string name, string type)
        {
            heroService.CreateHero(name, type);
        }


    }
}
