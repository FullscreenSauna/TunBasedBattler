using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TurnBasedBattler.Models;
using TurnBasedBattler.Models.DTOs;

namespace TurnBasedBattler.Services
{
    public class PlayerService
    {
        private readonly tunbasedbattlerContext dbContext;
        public PlayerService(tunbasedbattlerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreatePlayer(PlayerViewModel player )
        {
            Player newPlayer = new Player();

            newPlayer.Username = player.Username;

            dbContext.Players.Add(newPlayer);
            dbContext.SaveChanges();
        }

        public PlayerViewModel GetPlayerById(int id)
        {
            var dictionary = new Dictionary<PlayerViewModel, List<Hero>>();

            var playerViewModel = new PlayerViewModel();
            var player = this.dbContext
                             .Players
                             .Where(pl => pl.Id == id)
                             .Include(h => h.Heroes)
                             .FirstOrDefault();
            playerViewModel.Id = player.Id;
            playerViewModel.Username = player.Username;
            playerViewModel.Heroes = player.Heroes;

            return playerViewModel;
        }

        
    }
}
