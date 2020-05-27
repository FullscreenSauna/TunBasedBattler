using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Models;
using TurnBasedBattler.Models.DTOs;
using TurnBasedBattler.Services;
using TurnBasedBattler.Views;

namespace TurnBasedBattler.Controllers
{
    public class PlayerController
    {
        private readonly PlayerService playerService;
        private readonly PlayerView playerView;
        private PlayerViewModel player;

        public PlayerController(tunbasedbattlerContext dbContext)
        {
            playerService = new PlayerService(dbContext);
            playerView = new PlayerView();
            player = new PlayerViewModel();
        }

        public int PlayerId
        {
            get { return player.Id; }
            private set {; }
        }
        public void CreatePlayer(string username)
        {
            try
            {
                playerService.CreatePlayer(username);
            }
            catch (ArgumentException ex)
            {
                playerView.DisplayExceptionMessage(ex.Message);
            }
            player = playerService.GetPlayerByName(username);
        }

        public void DisplayStats(int id)
        {
            var playerViewModel = this.playerService.GetPlayerById(id);

            playerView.DisplayPlayerAndHeroes(playerViewModel);
        }

        public void ConnectPlayer(string name)
        {
            var playerViewModel = this.playerService.GetPlayerByName(name);
            player = playerViewModel;
        }


    }
}