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
            dbContext = new tunbasedbattlerContext();
            homeController = new HomeController(dbContext);
            Run();
        }

        public void Run()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.D9)
            {

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        homeController.GetPlayer();
                        break;
                    case ConsoleKey.D2:
                        homeController.CreatePlayer();
                        break;
                    case ConsoleKey.D3:
                        homeController.CreateHero();
                        break;
                    case ConsoleKey.D4:

                        break;
                    case ConsoleKey.D5:
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

