using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Models.DTOs
{
    public class HeroViewModel
    {
        public HeroViewModel()
        { }
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

<<<<<<< HEAD
=======
        public override string ToString()
        {
            var sb = new StringBuilder();

            decimal dodgePercantega = Dodge * 100;

            sb.Append($"{Name}- HP:{Hp} ATK:{Attack}/DEF:{Defence}/MAG:{Magic}/DodgeChance:{dodgePercantega:f0}%");

            return sb.ToString();
        }
>>>>>>> b56549389383f001d86d8b24c246d4b47e275570
    }
}
