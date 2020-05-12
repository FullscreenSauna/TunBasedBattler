using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Models.DTOs
{
    public class PlayerViewModel
    {
        public PlayerViewModel()
        {
            Heroes = new HashSet<Hero>();
        }

        public int Id { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
