using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Controllers;
using TurnBasedBattler.Models;

namespace TurnBasedBattler
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
            FirstRun();
        }

        private void GameTitle()
        {
            //Make it big
            Console.WriteLine("TurnBasedBattler");
        }

        private void GetStartMenu()
        {
            homeController.StartMenu();
        }

        private void FirstRun()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            try
            {
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        homeController.ConnectPlayer();
                        Run();
                        break;
                    case ConsoleKey.D2:
                        homeController.CreatePlayer();
                        Run();
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
                FirstRun();
            }
        }

        private void Run()
        {
            homeController.Menu();
            ConsoleKeyInfo key = Console.ReadKey();
            while (true)
            {
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.D3:
                        homeController.CreateHero();
                        break;
                    case ConsoleKey.D4:
                        homeController.GetPlayerStatus();
                        break;
                    case ConsoleKey.D5:
                        homeController.GetHeroStatus();
                        break;
                    case ConsoleKey.D6:
                        break;
                    case ConsoleKey.D7:
                        break;
                    //return to the start menu
                    case ConsoleKey.D8:
                        GetStartMenu();
                        FirstRun();
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

