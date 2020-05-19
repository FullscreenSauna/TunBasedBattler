using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Security.Cryptography.X509Certificates;
using TurnBasedBattler.Controllers;
using TurnBasedBattler.Models;
using TurnBasedBattler.Services;

namespace TurnBasedBattler
{
    class Program
    {
        static void Main(string[] args)
        {
            //service.Create-- - Testing
            /////////  string name = Console.ReadLine();
            // string type = Console.ReadLine();

            ///////// PlayerViewModel pl = new PlayerViewModel();
            ////////pl.Username = name;
            ////////tunbasedbattlerContext dbContext = new tunbasedbattlerContext();
            ////////PlayerService ps = new PlayerService(dbContext);
            ////////ps.CreatePlayer(pl);
            // HeroService hs = new HeroService(dbContext);

            //  hs.CreateHero(name, type);
            //TODO UnitTests!!!
        }
    }
}
