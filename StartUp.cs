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
            Run();
        }

        public void GameTitle()
        {
            //Make it big
            Console.WriteLine("TurnBasedBattler");
        }
        public void Run()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.D9)
            {
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        homeController.GetPlayer();
                        // cant handle exeption===if you write your name wrong
                        break;
                    case ConsoleKey.D2:
                        homeController.CreatePlayer();
                        //you can see and edit a Player if you try to create player with the same name???
                        break;
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
