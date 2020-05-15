using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Services
{
    public class HeroService
    {
        private readonly tunbasedbattlerContext dbContext;

        public HeroService(tunbasedbattlerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public HeroViewModel CreateHero(string name, string type)
        {
           
            Hero newHero = null;

            if (type == "Brute")
            {
                newHero = new Brute(name);
            }
            else if (type == "Ranger")
            {
                newHero = new Ranger(name);
            }
            else if (type == "Paladin")
            {
                newHero = new Paladin(name);
            }
            else if (type == "Wizzard")
            {
                newHero = new Wizzard(name);
            }
            else
            {
                throw new ArgumentException("The hero type was not correct");
            }


            if (newHero != null)
            {
                this.dbContext.Heroes.Add(newHero);
                this.dbContext.SaveChanges();
            }
         
        }


        //TODO Make it with HeroViewService
        //public HeroViewModel CreateHero(HeroViewService newHero, string type)
        //{}





    }
}
