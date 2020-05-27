using System;
using System.Collections.Generic;
using System.Text;
using TurnBasedBattler.Models.DTOs;

namespace TurnBasedBattler.Views
{
    public class PlayerView
    {
        public PlayerView() { }

        public void DisplayPlayerAndHeroes(PlayerViewModel playerViewModel)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(playerViewModel.Username + ":");

            foreach (var hero in playerViewModel.Heroes)
            {
                sb.AppendLine($"    {hero.ToString()}");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        public void DisplayExceptionMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}


