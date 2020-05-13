using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Controllers
{
    public class CreateHeroController
    {

        public readonly List<Hero> newHeroes;

        public CreateHeroController()
        {
            newHeroes = new List<Hero>();
        }
        public void CreateHero(string name, string type)
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


            if (hero != null)
            {
                newHeroes.Add(hero);
            }
        }
    }
}
