using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Views
{
    class HeroView
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public int PlayerId { get; set; }

        public HeroView()
        { }

        public void HeroStatus(string status)
        {
            Console.WriteLine(status);
        }

        public List<string> CreateHero()
        {
            List<string> values = new List<string>();
            Console.WriteLine("Please enter a name for your new hero: ");
            values.Add(Console.ReadLine());
            ShowHeroTypes();
            Console.WriteLine("Please choose the type of your hero: ");
            values.Add(Console.ReadLine());

            return values;
        }

        public void ShowHeroTypes()
        {
            Console.WriteLine("Hero types:");
            Console.WriteLine("Brute");
            Console.WriteLine("Paladin");
            Console.WriteLine("Ranger");
            Console.WriteLine("Wizzard");
        }

        public string GetHeroStatus()
        {
            Console.WriteLine("Please enter the name of the hero: ");
            string name = Console.ReadLine();
            return name;
        }
    }
}