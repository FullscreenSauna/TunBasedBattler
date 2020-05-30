using System;
using System.Collections.Generic;
using System.Text;
using TunBasedBattler.Models;
using TunBasedBattler.Models.DTOs;

namespace TurnBasedBattler.Views
{
    public class BattleView
    {
        public List<string> GetParticipatingHeroes()
        {
            var heroNames = new List<string>();

            Console.WriteLine("Choose first hero:");
            heroNames.Add(Console.ReadLine());
            Console.WriteLine("Choose second hero:");
            heroNames.Add(Console.ReadLine());
            Console.WriteLine("Choose third hero:");
            heroNames.Add(Console.ReadLine());

            return heroNames;
        }

        public string GetNextHeroToAttack()
        {
            Console.WriteLine("Which hero should attack 1./2./3.");
            
            return Console.ReadKey().Key.ToString();
        }

        public void UpdateStatus(int bossHealth, Hero firstHero, Hero secondHero, Hero thirdHero)
        {
            Console.WriteLine($"Boss's HP = {bossHealth}");
            Console.WriteLine($"{firstHero.Name}'s HP = {firstHero.Hp}");
            Console.WriteLine($"{secondHero.Name}'s HP = {secondHero.Hp}");
            Console.WriteLine($"{thirdHero.Name}'s HP = {thirdHero.Hp}");
        }

        public void Success()
        {
            Console.WriteLine("Congrats you beat the boss");
        }

        public void Failiure()
        {
            Console.WriteLine("You didn't manage to beat the boss. Better luck next time");
        }
    }
}
