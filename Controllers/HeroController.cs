using System;
using System.Collections.Generic;
using System.Text;
using TunBasedBattler.Models;
using TunBasedBattler.Models.DTOs;
using TunBasedBattler.Services;
using TunBasedBattler.Views;

namespace TunBasedBattler.Controllers
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

        public void DeleteHero()
        {
            string name = heroView.GetHeroName();
            try
            {
                heroService.DeleteHero(name);
                heroView.SuccessfulDeletion(name);
            }
            catch (ArgumentException ex)
            {
                heroView.DisplayExceptionMessage(ex.Message);
            }
        }
    }
}