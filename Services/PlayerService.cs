using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TunBasedBattler.Models;
using TunBasedBattler.Models.DTOs;
using TurnBasedBattler.Views;

namespace TunBasedBattler.Services
{
    public class PlayerService
    {
        private const int bossDamage = 1500;

        private int bossHealth = 150;

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

            foreach (var hero in this.dbContext.Heroes.Where(p => p.PlayerId == id))
            {
                this.dbContext.Heroes.Remove(hero);
            }

            this.dbContext.Players.Remove(dbContext.Players.FirstOrDefault(p => p.Id == id));
            this.dbContext.SaveChanges();

        }

        public void VerifyBattle(PlayerViewModel player, List<string> heroes)
        {
            foreach (var hero in heroes)
            {
                if (dbContext.Heroes.FirstOrDefault(h => h.Name == hero) == null)
                {
                    throw new ArgumentException($"Player {player.Username} doesn't have a Hero named {hero}");
                }
            }
        }

        public void Battle(List<string> heroNames, BattleView battleView)
        {
            var firstHero = dbContext.Heroes.FirstOrDefault(h => h.Name == heroNames[0]);
            var secondHero = dbContext.Heroes.FirstOrDefault(h => h.Name == heroNames[1]);
            var thirdHero = dbContext.Heroes.FirstOrDefault(h => h.Name == heroNames[2]);

            while (firstHero.Hp > 0 && secondHero.Hp > 0 && thirdHero.Hp > 0 && bossHealth > 0)
            {
                switch (battleView.GetNextHeroToAttack())
                {
                    case "1":
                        BossTakeDamage(firstHero);
                        BossDealDamage(firstHero);
                        battleView.UpdateStatus(bossHealth, firstHero, secondHero, thirdHero);
                        break;
                    case "2":
                        BossTakeDamage(firstHero);
                        BossDealDamage(firstHero);
                        battleView.UpdateStatus(bossHealth, firstHero, secondHero, thirdHero);
                        break;
                    case "3":
                        BossTakeDamage(firstHero);
                        BossDealDamage(firstHero);
                        battleView.UpdateStatus(bossHealth, firstHero, secondHero, thirdHero);
                        break;
                }
            }

            if (bossHealth <= 0)
            {
                battleView.Success();
            }
            else
            {
                battleView.Failiure();
            }

            if (dbContext.Heroes.FirstOrDefault(h => h.Hp <= 0) != null)
            {
                dbContext.Heroes.Remove(dbContext.Heroes.FirstOrDefault(h => h.Hp <= 0));
                dbContext.SaveChanges();

            }
        }

        private void BossDealDamage(Hero hero)
        {
            dbContext.Heroes.FirstOrDefault(h => h == hero).Hp -= bossDamage;
            dbContext.SaveChanges();
        }

        private void BossTakeDamage(Hero hero)
        {
            if (hero.Attack >= hero.Magic)
            {
                bossHealth -= hero.Attack;
            }
            else
            {
                bossHealth -= hero.Magic;
            }
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
