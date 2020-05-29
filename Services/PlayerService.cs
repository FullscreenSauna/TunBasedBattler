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

        public void CreatePlayer(string username)
        {
            if (!Exists(username))
            {
                Player newPlayer = new Player();

                newPlayer.Username = username;

                dbContext.Players.Add(newPlayer);
                dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Player with name {username} already exists");
            }
        }

        public PlayerViewModel GetPlayerByName(string name)
        {
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
            }
            else
            {
                throw new ArgumentException($"Player {name} does not exist");
            }
            return playerViewModel;
        }

        public void DeletePlayer(int id, string confirmation)
        {
            if (confirmation.ToLower() != "yes")
            {
                throw new ArgumentException("Failed to confirm the deletion process");
            }

            foreach (var hero in this.dbContext.Heroes)
            {
                this.dbContext.Heroes.Remove(hero);
            }

            this.dbContext.Players.Remove(dbContext.Players.FirstOrDefault(p => p.Id == id));
            this.dbContext.SaveChanges();

        }

        public List<string> GetAllPlayerNames()
        {
            return this.dbContext.Players.Select(p => p.Username).ToList();
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

        public bool Exists(string name)
        {
            Player player = dbContext.Players.Where(p => p.Username == name).FirstOrDefault();
            if (player == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Exists(int id)
        {
            Player player = dbContext.Players.Where(p => p.Id == id).FirstOrDefault();
            if (player == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
