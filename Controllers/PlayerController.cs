using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Services;

namespace TurnBasedBattler.Controllers
{
    public class PlayerController
    {
        private readonly PlayerService playerService;

        public PlayerController(PlayerService playerService)
        {
            this.playerService = playerService;
        }

        public void DisplayStats(int id)
        {
            var playerViewModel = this.playerService.GetPlayerById(id);

            //TODO: Add the View
        }
    }
}
