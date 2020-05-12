using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Models.DTOs
{
    public class HeroViewModel
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
    }
}
