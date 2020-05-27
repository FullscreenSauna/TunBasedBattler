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

        public void CreatePlayer(PlayerViewModel player)
        {
            try
            {
                Player newPlayer = new Player();

                newPlayer.Username = player.Username;

                dbContext.Players.Add(newPlayer);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine($"Player with name {player.Username} already exists");
            }
        }

        public PlayerViewModel GetPlayerByName(string name)
        {
            //TODO FIX
            var dictionary = new Dictionary<PlayerViewModel, List<Hero>>();
            var playerViewModel = new PlayerViewModel();
            var player = this.dbContext
                             .Players
                             .Where(pl => pl.Username == name)
                             .Include(h => h.Heroes)
                             .FirstOrDefault();
            if (player != null)
            {
                playerViewModel.Id = player.Id;
                playerViewModel.Username = player.Username;
                playerViewModel.Heroes = HeroCollectionToHeroViewModelCollection(player.Heroes);
                return playerViewModel;
            }
            else
            {
                return null;
                throw new ArgumentException($"Hero {name} does not exist");
            }
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
            playerViewModel.Heroes = HeroCollectionToHeroViewModelCollection(player.Heroes);

            return playerViewModel;
        }


        private List<HeroViewModel> HeroCollectionToHeroViewModelCollection(ICollection<Hero> heroes)
        {
            List<HeroViewModel> heroViewModels = new List<HeroViewModel>();
            foreach (var hero in heroes)
            {
                HeroViewModel heroViewModel = new HeroViewModel();
                heroViewModel.Id = hero.Id;
                heroViewModel.Name = hero.Name;
                heroViewModel.Hp = hero.Hp;
                heroViewModel.Magic = hero.Magic;
                heroViewModel.Attack = hero.Attack;
                heroViewModel.Defence = hero.Defence;
                heroViewModel.Dodge = hero.Dodge;
                heroViewModel.PlayerId = hero.PlayerId;

                heroViewModels.Add(heroViewModel);
            }
            return heroViewModels;
        }

    }
}