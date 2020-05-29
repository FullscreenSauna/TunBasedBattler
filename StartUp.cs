using System;
using System.Collections.Generic;
using System.Text;
using TunBasedBattler.Controllers;
using TunBasedBattler.Models;

namespace TunBasedBattler
{
    public class StartUp
    {
        private HomeController homeController;
        private readonly tunbasedbattlerContext dbContext;
        public StartUp()
        {
            GameTitle();
            dbContext = new tunbasedbattlerContext();
            homeController = new HomeController(dbContext);
            GetStartMenu();
        }

        private void GameTitle()
        {
            //Make it big
            Console.WriteLine("TunBasedBattler");
        }

        private void GetStartMenu()
        {
            homeController.StartMenu();
            StartMenuFlow();
        }

        private void StartMenuFlow()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            try
            {
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        homeController.ConnectPlayer();
                        break;
                    case ConsoleKey.D2:
                        homeController.CreatePlayer();
                        break;
                    case ConsoleKey.D3:
                        homeController.DisplayAllPlayerNames();
                        GetStartMenu();
                        break;
                    case ConsoleKey.D9:
                        Environment.Exit(0);
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                homeController.DisplayExeptionMessage(ex.Message);
                GetStartMenu();
                StartMenuFlow();
            }

            MainMenuFlow();
        }

        private void MainMenuFlow()
        {
            homeController.Menu();
            ConsoleKeyInfo key = Console.ReadKey();
            while (true)
            {
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        homeController.CreateHero();
                        break;
                    case ConsoleKey.D2:
                        homeController.GetPlayerStatus();
                        break;
                    case ConsoleKey.D3:
                        homeController.GetHeroStatus();
                        break;
                    case ConsoleKey.D4:
                        homeController.DeleteHero();
                        break;
                    case ConsoleKey.D5:
                        homeController.DeletePlayer();
                        GetStartMenu();
                        break;
                    case ConsoleKey.D6:
                        homeController.InitiateBattle();
                        break;
                    case ConsoleKey.D8:
                        GetStartMenu();
                        break;
                    case ConsoleKey.D9:
                        Environment.Exit(0);
                        break;
                }

                homeController.Menu();
                key = Console.ReadKey();
            }
        }

    }
}

