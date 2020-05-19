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
            Hero newHero = HeroWithType(hero.Name, hero.Type);
            newHero.PlayerId = hero.PlayerId;

            this.dbContext.Heroes.Add(newHero);
            this.dbContext.SaveChanges();
        }


        public void DeleteHero(HeroViewModel deadHero)
        {
            Hero heroToDelete = this.dbContext
                .Heroes
                .FirstOrDefault(h => h.Name == deadHero.Name);

            this.dbContext.Heroes.Remove(heroToDelete);
            this.dbContext.SaveChanges();
        }

        private Hero HeroWithType(string name, string type)
        {
            try
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
                    throw new ArgumentNullException("The hero type was not correct");
                }

                return hero;

            }
            catch (ArgumentNullException incorrectHeroName)
            {
                //FixThis
                throw incorrectHeroName;
            }
        }
    }

}