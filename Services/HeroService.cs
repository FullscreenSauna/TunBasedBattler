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

        public void CreateHero(HeroViewModel hero)
        {
            if (GetHeroByName(hero).Hp == 0)
            {
                try
                {
                    Hero newHero = HeroWithType(hero.Name, hero.Type);
                    newHero.PlayerId = hero.PlayerId;

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
                Console.WriteLine($"Hero with name {hero.Name} already exists");
            }
        }


        public void DeleteHero(HeroViewModel deadHero)
        {
            try
            {
                Hero heroToDelete = GetHeroByName(deadHero);

                this.dbContext.Heroes.Remove(heroToDelete);
                this.dbContext.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"Hero with name \"{deadHero.Name}\" does not exist");
            }
        }

        public string GetHeroStatus(HeroViewModel hero)
        {
            try
            {
                HeroViewModel redultHero = ToHeroViewModel(GetHeroByName(hero));
                return redultHero.ToString();
            }
            catch (ArgumentException ex)
            {

                return ex.Message;
            }
        }

        public Hero GetHeroByName(HeroViewModel heroToFind)
        {
            Hero foundHero = this.dbContext
                .Heroes
                .FirstOrDefault(h => h.Name == heroToFind.Name);
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
                throw new ArgumentException("The hero type was not correct");
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
                return heroToReturn;

            }
            else
            {
                throw new ArgumentException("Hero does not exist or is dead");
            }


        }
    }
}