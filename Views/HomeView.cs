using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Models.DTOs;

namespace TurnBasedBattler.Views
{
    public class HomeView
    {
        private readonly PlayerView playerView;
        private readonly HeroView heroView;

        public HomeView()
        {
            StartMenu();
            playerView = new PlayerView();
            heroView = new HeroView();
        }
        public void StartMenu()
        {
            Console.WriteLine("1.I have a player");
            Console.WriteLine("2.Create player");
            Console.WriteLine("9.Exit");
        }

        public void Menu()
        {
            Console.WriteLine("3.Create hero");
            Console.WriteLine("4.Player status");
            Console.WriteLine("5.Hero status");
            //Console.WriteLine("6.Battle");
            //Console.WriteLine("7.");
            Console.WriteLine("8.Go to the start menu");
            Console.WriteLine("9.Exit");
        }

        public string GetPlayerName()
        {
            return playerView.GetPlayerName();
        }

        public string CreatePlayer()
        {
            return playerView.CreatePlayer();
        }

        public List<string> CreateHero()
        {
            return heroView.CreateHero();
        }

        public void DisplayExceptionMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetHeroStatus()
        {
            return heroView.GetHeroStatus();
        }

        public void Battle()
        {
            Console.WriteLine("Choose first hero: ");
            string firstHeroName = Console.ReadLine();
            Console.WriteLine("Choose second hero: ");
            string secondHeroName = Console.ReadLine();
            //???
        }
     


    }
}
