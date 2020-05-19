using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Security.Cryptography.X509Certificates;
using TurnBasedBattler.Controllers;
using TurnBasedBattler.Models;
using TurnBasedBattler.Models.DTOs;
using TurnBasedBattler.Services;

namespace TurnBasedBattler
{
    class Program
    {
        static void Main(string[] args)
        {
            ////  //service.Create-- - Testing
            //string name = Console.ReadLine();
            //string type = Console.ReadLine();

            //  tunbasedbattlerContext dbContext = new tunbasedbattlerContext();
            //HeroService hs = new HeroService(dbContext);
            //HeroController hc = new HeroController(hs);
            //HeroViewModel hvm = new HeroViewModel();
            //  hvm.Name = name;
            // hvm.Type = type;
            // hvm.PlayerId = 1;

            // hc.CreateHero(hvm);
            ////  ///////// PlayerViewModel pl = new PlayerViewModel();
            ////  ////////pl.Username = name;
            ////  ///PlayerService ps = new PlayerService(dbContext);
            ////  ////////ps.CreatePlayer(pl);
            ////  //TODO UnitTests!!!
        }
    }
}
