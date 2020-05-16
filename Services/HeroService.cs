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

        public void CreateHero(string name, string type)
        {

            Hero newHero = HeroWithType(name, type);


            this.dbContext.Heroes.Add(newHero);
            this.dbContext.SaveChanges();
        }


        private Hero HeroWithType(string name, string type)
        {
            Hero hero = null;
            if (type == "Brute")
            {
                hero = new Brute(name);
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

        //public void DeleteHero(HeroViewModel deadHero)
        //{
        //    this.dbContext.Heroes.Remove(deadHero);
        //    this.dbContext.SaveChanges();
        //}
    }

}
