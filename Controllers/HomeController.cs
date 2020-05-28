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

        public HomeController(tunbasedbattlerContext dbContext)
        {
            this.heroController = new HeroController(dbContext);
            this.playerController = new PlayerController(dbContext);
            homeView = new HomeView();
        }

        public void ConnectPlayer()
        {
            string name = homeView.GetPlayerName();
            playerController.ConnectPlayer(name);
        }

        public void CreatePlayer()
        {
            string username = homeView.CreatePlayer();
            playerController.CreatePlayer(username);
        }

        public void CreateHero()
        {
            List<string> values = homeView.CreateHero();
            string name = values[0];
            string type = values[1];
            int id = playerController.PlayerId;
            heroController.CreateHero(name, type, id);
        }

        public void GetPlayerStatus()
        {
            playerController.DisplayStats(playerController.PlayerId);
        }

        public void DeleteHero()
        {
            heroController.DeleteHero();
        }

        public void DeletePlayer()
        {
            playerController.DeletePlayer();
        }

        public void DisplayExeptionMessage(string message)
        {
            homeView.DisplayExceptionMessage(message);
        }

        public void GetHeroStatus()
        {
            heroController.HeroStatus(homeView.GetHeroStatus(), playerController.PlayerId);
        }

        public void Menu()
        {
            homeView.Menu();
        }

        public void StartMenu()
        {
            homeView.StartMenu();
        }

       
    }
}
