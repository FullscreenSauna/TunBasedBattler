using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Views
{
    class HeroView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }

        public int PlayerId { get; set; }
    }
}
