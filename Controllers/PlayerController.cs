using System;
using System.Collections.Generic;
using System.Text;
using TunBasedBattler.Models;
using TunBasedBattler.Models.DTOs;
using TunBasedBattler.Services;
using TunBasedBattler.Views;

namespace TunBasedBattler.Controllers
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

        public void DeletePlayer()
        {
            string confirmation = playerView.DeletionWarning(player.Username);

            try
            {
                playerService.DeletePlayer(player.Id, confirmation);
                playerView.SuccessfulDeletion(player.Username);
            }
            catch (ArgumentException ex)
            {

                playerView.DisplayExceptionMessage(ex.Message);
            }
        }

        public void GetAllPlayerNames()
        {
            playerView.DisplayAllPlayerNames(playerService.GetAllPlayerNames());
        }
    }
}