using System;
using System.Collections.Generic;

namespace TurnBasedBattler.Models
{
    public class Player
    {
        public Player()
        {
            Heroes = new HashSet<Hero>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
