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
            StartUp st = new StartUp();
            //service-- - testing


            ////CreatePlayerTest
            //string name = Console.ReadLine();
            //tunbasedbattlerContext dbContext = new tunbasedbattlerContext();
            //PlayerService ps = new PlayerService(dbContext);
            //PlayerViewModel pl = new PlayerViewModel();
            //pl.Username = name;
            //ps.CreatePlayer(pl);



            ////CreateHeroTest
            //string name = Console.ReadLine();
            //string type = Console.ReadLine();
            //tunbasedbattlerContext dbContext = new tunbasedbattlerContext();
            //HeroService hs = new HeroService(dbContext);
            //HeroViewModel hvm = new HeroViewModel();
            //hvm.Name = name;
            //hvm.Type = type;
            //hvm.PlayerId = 1;
            //hs.CreateHero(hvm);

            ////DeleteHeroTest
            //string name = Console.ReadLine();
            //tunbasedbattlerContext dbContext = new tunbasedbattlerContext();
            //HeroService hs = new HeroService(dbContext);
            //HeroController hc = new HeroController(hs);
            //HeroViewModel hvm = new HeroViewModel();
            //hvm.Name = name;
            //hc.DeleteHero(hvm);


            ////HeroStatusTest
            //string name = Console.ReadLine();
            //tunbasedbattlerContext dbContext = new tunbasedbattlerContext();
            //HeroService hs = new HeroService(dbContext);
            //HeroController hc = new HeroController(hs);
            //HeroViewModel sameHero = new HeroViewModel();
            //sameHero.Name = name;
            //Console.WriteLine(hc.HeroStatus(sameHero)); 

            ////  //TODO UnitTests!!!
        }
    }
}
