using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnBasedBattler.Models;
using TurnBasedBattler.Models.DTOs;
using TurnBasedBattler.Models.Entities;
using TurnBasedBattler.Models.Entities.Heroes;
using TurnBasedBattler.Views;

namespace TurnBasedBattler.Services
{
    public class HeroService
    {
        private readonly tunbasedbattlerContext dbContext;

        public HeroService(tunbasedbattlerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateHero(string name, string type, int id)
        {
            if (GetHeroByName(name) == null)
            {
                try
                {
                    Hero newHero = HeroWithType(name, type);
                    newHero.PlayerId = id;

                    this.dbContext.Heroes.Add(newHero);
                    this.dbContext.SaveChanges();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine($"Hero with name {name} already exists");
            }
        }


        public void DeleteHero(HeroViewModel deadHero)
        {

            try
            {
                Hero heroToDelete = GetHeroByName(deadHero.Name);

                this.dbContext.Heroes.Remove(heroToDelete);
                this.dbContext.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"Hero with name \"{deadHero.Name}\" does not exist");
            }
        }

        public string GetHeroStatus(string name, int playerId)
        {
            try
            {
                HeroViewModel resultHero = ToHeroViewModel(GetHeroByName(name));
                if (resultHero.PlayerId == playerId)
                {
                    return resultHero.ToString();
                }
                else
                {
                    return $"You don`t have hero {name}";
                }
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }

        private Hero GetHeroByName(string name)
        {
            Hero foundHero = this.dbContext
                .Heroes
                .FirstOrDefault(h => h.Name == name);
            return foundHero;
        }

        private Hero HeroWithType(string name, string type)
        {
            Hero hero = new Hero();
            if (type == "Brute")
            {
                hero = new Brute(name);
                //Brute brute = new Brute();
                //hero = brute.GetDefaultValues(name);
            }
            else if (type == "Ranger")
            {
                hero = new Ranger(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Wizzard")
            {
                hero = new Wizzard(name);
            }
            else
            {
                throw new ArgumentException("The type was not correct");
            }

            return hero;

        }

        private HeroViewModel ToHeroViewModel(Hero hero)
        {
            if (hero != null)
            {
                HeroViewModel heroToReturn = new HeroViewModel();
                heroToReturn.Name = hero.Name;
                heroToReturn.Hp = hero.Hp;
                heroToReturn.Attack = hero.Attack;
                heroToReturn.Defence = hero.Defence;
                heroToReturn.Magic = hero.Magic;
                heroToReturn.Dodge = hero.Dodge;
                heroToReturn.PlayerId = hero.PlayerId;
                return heroToReturn;

            }
            else
            {
                throw new ArgumentException("Hero does not exist or is dead");
            }


        }
    }
}