using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Views
{
    class HeroView
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public int PlayerId { get; set; }

        public HeroView()
        { }

        public void HeroStatus(string status)
        {
            Console.WriteLine(status);
        }

    }
}