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

        public void GameTitle()
        {
            //Make it big
            Console.WriteLine("TurnBasedBattler");
        }

        public void GetStartMenu()
        {
            homeController.StartMenu();
        }

        public void FirstRun()
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

        public void Run()
        {
            homeController.Menu();
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.D9)
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
                    case ConsoleKey.D8:
                        break;
                }

                homeController.Menu();
                key = Console.ReadKey();
            }
        }

    }
}

