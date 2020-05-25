using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Models.DTOs;

namespace TurnBasedBattler.Views
{
    public class HomeView
    {

        public HomeView()
        {
            StartMenu();
        }
        public void StartMenu()
        {
            Console.WriteLine("1.I have account");
            Console.WriteLine("2.Create account");
            Console.WriteLine("9.Exit");
        }

        public void Menu()
        {
            Console.WriteLine("3.Create hero");
            Console.WriteLine("4.My status");
            Console.WriteLine("5.Status of hero");
            Console.WriteLine("6.Make battle");
            Console.WriteLine("7.");
            Console.WriteLine("9.Exit");
        }

        public string GetPlayer()
        {
            Console.WriteLine("Please enter username: ");
            string username = Console.ReadLine();
            return username;
        }

        public PlayerViewModel CreatePlayer()
        {
            Console.WriteLine("Please enter username: ");
            string userName = Console.ReadLine();
            //ToDo password??
            //Console.WriteLine("Please enter password: ");
            //string password = Console.ReadLine();
            PlayerViewModel newPlayer = new PlayerViewModel();
            newPlayer.Username = userName;
            return newPlayer;
        }

        public HeroViewModel CreateHero()
        {
            Console.WriteLine("Please enter a name for your new hero: ");
            string name = Console.ReadLine();
            ShowHeroTypes();
            Console.WriteLine("Please choose the type of your hero: ");
            string type = Console.ReadLine();
            HeroViewModel newHero = new HeroViewModel();
            newHero.Name = name;
            newHero.Type = type;
            return newHero;
        }

        public void ShowHeroTypes()
        {
            Console.WriteLine("Hero types:");
            Console.WriteLine("Brute");
            Console.WriteLine("Paladin");
            Console.WriteLine("Ranger");
            Console.WriteLine("Wizzard");
        }
    }
}

