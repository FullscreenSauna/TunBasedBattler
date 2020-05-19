using Renci.SshNet.Security.Cryptography.Ciphers.Modes;
using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Services;

namespace TurnBasedBattler.Controllers
{
    class HomeController
    {
        private readonly PlayerService playerService;
        private readonly HeroService heroService;
        public HomeController(PlayerService playerService, HeroService heroService)
        {
            this.playerService = playerService;
            this.heroService = heroService;
        }

    }
}
