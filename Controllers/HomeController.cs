using Microsoft.EntityFrameworkCore;
using Renci.SshNet.Security.Cryptography.Ciphers.Modes;
using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Models;
using TurnBasedBattler.Models.DTOs;
using TurnBasedBattler.Services;
using TurnBasedBattler.Views;

namespace TurnBasedBattler.Controllers
{
    class HomeController
    {
        private HeroController heroController;
        private PlayerController playerController;
        private readonly HomeView homeView;
        private PlayerViewModel player;
        public HomeController(tunbasedbattlerContext dbContext)
        {
            this.heroController = new HeroController(dbContext, player);
            this.playerController = new PlayerController(dbContext);
            player = new PlayerViewModel();
            homeView = new HomeView();
        }

        public void GetPlayer()
        {
            string name = homeView.GetPlayer();
            player = playerController.GetPlayer(name);
        }

        public void CreatePlayer()
        {
            PlayerViewModel newPlayer = homeView.CreatePlayer();
            playerController.CreatePlayer(newPlayer);
            player = playerController.GetPlayer(newPlayer.Username);
        }

        public void CreateHero()
        {
            HeroViewModel newHero = homeView.CreateHero();
            newHero.PlayerId = player.Id;
            heroController.CreateHero(newHero);
            player.Heroes.Add(newHero);
        }

        public void GetPlayerStatus()
        {
            playerController.DisplayStats(player.Id);
        }
        public void GetHeroStatus()
        {
            heroController.HeroStatus(homeView.GetHeroStatus(), player.Id);
        }

        public void Menu()
        {
            homeView.Menu();
        }

    }
}
