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


        public PlayerController(tunbasedbattlerContext dbContext)
        {
            this.playerService = new PlayerService(dbContext);
            this.playerView = new PlayerView(); //must take this from the constructor
        }

        public void CreatePlayer(PlayerViewModel player)
        {
            playerService.CreatePlayer(player);
        }

        public void DisplayStats(int id)
        {
            var playerViewModel = this.playerService.GetPlayerById(id);

            playerView.DisplayPlayerAndHeroes(playerViewModel);
        }
        public PlayerViewModel GetPlayer(string name)
        {
            var playerViewModel = this.playerService.GetPlayerByName(name);

            return (playerViewModel);
        }
    }
}
