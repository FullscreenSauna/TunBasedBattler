using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Models.DTOs;
using TurnBasedBattler.Services;
using TurnBasedBattler.Views;

namespace TurnBasedBattler.Controllers
{
    public class PlayerController
    {
        private readonly PlayerService playerService;
        private readonly PlayerView playerView;

         
        public PlayerController(PlayerService playerService, PlayerView playerView)
        {
            this.playerService = playerService;
            this.playerView = playerView;
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
    }
}
