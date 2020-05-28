using System;
using System.Collections.Generic;

namespace TurnBasedBattler.Models
{
    public class Hero
    {
        private string name;

        public int Id { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Name must be at most 50 charecters");
                }

                name = value;
            }
        }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Magic { get; set; }
        public decimal Dodge { get; set; }
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }


        public Hero()
        {
        }
        protected Hero(string name, int attack, int defence, int magic, decimal dodge, int hp)
        {
            Name = name;
            Attack = attack;
            Defence = defence;
            Magic = magic;
            Dodge = dodge;
            Hp = hp;
        }
    }
}
