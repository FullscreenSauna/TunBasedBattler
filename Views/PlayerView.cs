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

            sb.AppendLine("name: " + playerViewModel.Username + ":");

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

        public string GetPlayerName()
        {
            Console.WriteLine("Please enter username: ");
            string username = Console.ReadLine();
            return username;
        }

        public string CreatePlayer()
        {
            Console.WriteLine("Please enter username: ");
            string username = Console.ReadLine();

            return username;
        }

        public string DeletionWarning(string username)
        {
            Console.WriteLine($"You are about to delete {username} and all of their heroes");
            Console.WriteLine("If you want to proceed type Yes");
            return Console.ReadLine();
        }

        public void SuccessfulDeletion(string name)
        {
            Console.WriteLine($"Successfully deleted the player: {name}");
        }

    }
}


