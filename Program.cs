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
            StartUp start = new StartUp();
        }
    }
}
