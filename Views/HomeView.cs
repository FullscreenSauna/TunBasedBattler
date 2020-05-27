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
            Console.WriteLine("8.");
            Console.WriteLine("9.Exit");
        }

        public string GetPlayerName()
        {
            Console.WriteLine("Please enter username: ");
            string username = Console.ReadLine();
            return username;
        }

        public string CreatePlayer()
        {
            Console.WriteLine("Please enter username: ");
            string username = Console.ReadLine();

            return username;
        }

        public List<string> GetNameAndType()
        {
            List<string> values = new List<string>();
            Console.WriteLine("Please enter a name for your new hero: ");
            values.Add(Console.ReadLine());
            ShowHeroTypes();
            Console.WriteLine("Please choose the type of your hero: ");
            values.Add(Console.ReadLine());

            return values;
        }

        public string GetHeroStatus()
        {
            Console.WriteLine("Please enter the name of the hero: ");
            string name = Console.ReadLine();
            return name;
        }

        public void Battle()
        {
            Console.WriteLine("Choose first hero: ");
            string firstHeroName = Console.ReadLine();
            Console.WriteLine("Choose second hero: ");
            string secondHeroName = Console.ReadLine();
            //???
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
