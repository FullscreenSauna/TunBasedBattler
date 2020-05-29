using System;
using System.Collections.Generic;

namespace TunBasedBattler.Models
{
    public class Player
    {
        private string username;

        public Player()
        {
            Heroes = new HashSet<Hero>();
        }

        public int Id { get; set; }
        public string Username
        {
            get { return username; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Name must be at most 50 charecters");
                }

                username = value;
            }
        }
        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
