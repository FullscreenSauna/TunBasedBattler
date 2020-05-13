using System;
using System.Collections.Generic;

namespace TurnBasedBattler.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Magic { get; set; }
        public decimal Dodge { get; set; }
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        protected Hero(string name, int attack, int deffence, int magic, double dodge, int hp)
        {
            Name = name;
            Attack = attack;
            Deffence = deffence;
            Magic = magic;
            Dodge = dodge;
            Hp = hp;
        }
    }
}
