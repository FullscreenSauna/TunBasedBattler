using System;
using System.Collections.Generic;
using System.Text;

namespace TunBasedBattler.Models.DTOs
{
    public class PlayerViewModel
    {
        public PlayerViewModel()
        {
            Heroes = new List<HeroViewModel>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public List<HeroViewModel> Heroes { get; set; }
    }
}

