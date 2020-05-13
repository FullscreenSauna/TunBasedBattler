using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedBattler.Models.Entities.Heroes
{
    class Paladin : Hero
    {
        private const int InitialPaladinHp = 125;
        private const int PaladinAttackModifier = 2;
        private const int PaladinDeffenceModifier = 5;
        private const int PaladinMagicModifier = 1;
        private const double PaladinDodgeModifier = 0.01;
        public Paladin(string name)
            : base(name, PaladinAttackModifier, PaladinDeffenceModifier, PaladinMagicModifier, PaladinDodgeModifier, InitialPaladinHp)
        {
        }
    }
}