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
        public HeroController(HeroService heroService)
        {
            this.heroService =  heroService;
        }

        public void CreateHero(HeroViewModel newHero)
        {
            heroService.CreateHero(newHero);
        }


    }
}
